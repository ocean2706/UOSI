# UOSI (Universal Operating System Installer)

A modular, lightweight bare-metal installation engine, orchestration framework, and disaster recovery platform built on an Alpine Linux base.

UOSI replaces traditional, rigid distribution installers with an extensible Python micro-core. It handles local installs, network boot provisioning, configuration management, and zero-local-staging disaster recovery across Linux and BSD distributions.

---

## Architectural Principles

- **Minimal Alpine Base:** Operates with a minimal RAM footprint, probing hardware via `/sys` and PCI tables, loading kernel modules strictly on demand.
- **Concurrent VT Architecture & Remote Multiplexing:**
  - **VT1 (Installer Wizard):** Primary interactive wizard (CLI, ncurses, or lightweight Wayland/X11).
  - **VT2 (Root Shell):** Unrestricted debugging terminal to inspect devices, test mounts, or partition manually without disrupting wizard state.
  - **VT3 (Log Sink):** Real-time system, kernel, and process event logs.
  - **SSH Terminal Sharing:** Active SSH service multiplexed via `tmux`/`screen` so remote operators share the exact console session.
- **Passive-First Network Reconnaissance:** Inspects ARP, LLDP, and existing DHCP offers before assigning addresses or starting server daemons.
- **Cross-Platform Chroot Engine:** Bypasses host/target compatibility boundaries (such as Alpine musl vs. target glibc) by generating and executing self-contained, distribution-native provisioning scripts inside the target chroot.
- **Hardware-Aware Safety Gates:** Distinguishes chassis form-factors (server vs. laptop), checks for complex storage artifacts (LVM, Software RAID, Btrfs, ZFS), verifies snapshot capability, and enforces a triple-confirmation gate before destructive actions.
- **Reproducible State Machine:** Tracks every parameter in a unified, replayable JSON transaction log.

---

## Operating Modes

```text
UOSI Engine
|-- Mode-1: Network Boot Deployer (TFTP / PXE / BOOTP Appliance)
|-- Mode-2: Ansible Mass Delivery Orchestrator
|-- Mode-3: Local Media / Native OS Installer
|-- Mode-4: RootFS Tar Restorer (.tar.uosi.xz Deployment)
|-- Mode-5: Network Repository & Manifest Installer
|-- Mode-6: Native Installer Passthrough (Kickstart / Preseed / Subiquity)
`-- Disaster Recovery (DR): Backup Agent & Streaming Server
```

### Mode Breakdown

* **Mode-1 (Network Boot Appliance):** Converts the live node into a temporary (in-memory) or permanent network boot appliance. Integrates with `BootpManager` to serve BIOS/UEFI iPXE binaries, mirror installation media, log BOOTP requests, and enforce MAC-based admin authorization gates.
* **Mode-2 (Ansible Mass Delivery):** Sweeps the local broadcast domain or consumes static inventories to execute baseline orchestration playbooks (node bootstrapping, hypervisor setup, security hardening) across discovered targets.
* **Mode-3 (Native OS Installer):** Context-aware installer for local storage. Supports custom layouts, LVM + ext4, or Btrfs subvolumes (`@rootfs`, `@home`). Configures basic SSH, provisions an `nftables` firewall, injects user accounts, and creates an installation backup archive prior to reboot.
* **Mode-4 (RootFS Tar Restorer):** Restores `.tar.uosi.xz` archives, automatically rebuilding partition layouts and bootloaders using embedded metadata.
* **Mode-5 (Network Repository Installer):** Downloads package lists and filesystem manifests from custom HTTP/HTTPS repositories to stage systems directly on raw disks.
* **Mode-6 (Native Installer Passthrough):** Automates vendor-native installation engines via generated answer files (Debian Preseed, RHEL Kickstart, Ubuntu Subiquity).
* **Disaster Recovery Subsystem:** Stream-based backup and restore engine designed to operate without consuming local disk space for staging. Supports coordinated multi-disk snapshots, cold-cutover tar migration pipes, and live database streaming.

---

## Target Platforms

- **Linux:** Debian, Ubuntu, RHEL / Rocky / Alma, Fedora, Arch Linux, Alpine Linux.
- **BSD:** FreeBSD, OpenBSD, NetBSD (UFS2 and automated root-on-ZFS layouts).
- **Hypervisors & Cloud Fabrics:** Xen / XCP-ng, Proxmox VE, KVM, OpenStack, CloudStack, and MAAS nodes with custom `cloud-init` hooks.

---

## Storage & Archive Formats

### 1. Hybrid Boot Media Layout
UOSI boot media uses a hybrid partition scheme compatible with Windows, macOS, and Linux:

| Partition | Type | Filesystem | Role |
| :--- | :--- | :--- | :--- |
| **Partition 1** | Primary | **exFAT / NTFS** | Windows-accessible storage for local ISOs, raw rootfs images, and JSON manifests. |
| **Partition 2** | ESP | **FAT32** | UEFI System Partition containing bootloaders (`BOOTX64.EFI`, iPXE). |
| **Partition 3** | Primary | **ext4 / SquashFS** | Alpine Linux base system, UOSI core engine, and Python runtime. |

### 2. The `.tar.uosi.xz` Archive Standard
Stand-alone portable system backups are packaged with root-level recovery metadata:

```text
archive.tar.uosi.xz
|-- .uosi.init.json        # Disk geometry, UUIDs, filesystem types, mount table, bootloader specs
|-- .uosi.git/             # Embedded Git repository tracking /etc revisions and configuration diffs
|-- bin/
|-- etc/
|-- usr/
`-- ...                    # RootFS payload
```

### 3. Remote Storage Backends
Mounts remote storage providers on demand for image caches, root filesystems, and backup sinks:
- **Block:** Local NVMe/SATA/SAS, iSCSI (`iscsiadm`), Ceph RBD (`rbd map`), NBD, FCoE.
- **File & Object:** NFS (v3, v4.1/v4.2), CephFS, S3-compatible buckets (via FUSE).

---

## Project Structure

```text
uosi/
|-- build/                 # Alpine custom ISO and boot media build recipes
|-- core/                  # Engine micro-core
|   |-- engine.py          # State machine, step dispatcher, signal handlers
|   |-- session.py         # Thread-safe JSON state store and journal
|   |-- hardware.py        # DMI heuristics, sysfs/PCI on-demand module loader
|   |-- network.py         # Passive sniffers (ARP/LLDP/DHCP), IP assignment, proxy setup
|   `-- tui/               # Interface drivers (raw CLI, ncurses/whiptail, Wayland/X11)
|-- providers/
|   |-- storage/           # Pluggable storage drivers
|   |   |-- base.py        # Abstract storage interface (probe, mount, snapshot)
|   |   |-- lvm.py         # LVM volume group and thin-pool operations
|   |   |-- btrfs.py       # Btrfs subvolume layout and snapshot checks
|   |   |-- zfs.py         # ZFS zpool and dataset handlers
|   |   |-- remote.py      # NFS, S3/FUSE, iSCSI, NBD, FCoE, and Ceph drivers
|   |   `-- dedup.py       # Binary delta and chunk-level deduplication handlers
|   `-- targets/           # Distro-native chroot script generators
|       |-- base.py        # Chroot provisioning contract
|       |-- debian.py      # Debian/Ubuntu post-install script generator
|       |-- rhel.py        # RHEL/CentOS/Rocky script generator
|       |-- arch.py        # Arch Linux script generator
|       |-- alpine.py      # Alpine Linux native script generator
|       `-- bsd.py         # FreeBSD/OpenBSD bsdinstall script generator
|-- modes/                 # Executable wizard modes
|   |-- mode1_pxe.py       # Network boot deployer
|   |-- mode2_ansible.py   # Ansible mass delivery orchestrator
|   |-- mode3_install.py   # Native storage partitioner and OS extractor
|   |-- mode4_restore.py   # RootFS archive deployment
|   |-- mode5_netrepo.py   # Network manifest package streaming
|   `-- mode6_native.py    # Kickstart/Preseed chainloader
|-- backup/                # Zero-local-staging backup subsystem
|   |-- agent/             # Client streaming agent (I/O probe, snapshotter, TLS stream)
|   `-- server/            # Backup receiver, catalog, and indexer
`-- factory/               # Image generation pipeline (rootfs, ISO, and cloud templates)
```

---

## Quick Start

### Build Prerequisites
- Alpine Linux 3.19+ (or Docker builder container)
- Python 3.10+
- Host packages: `parted`, `e2fsprogs`, `btrfs-progs`, `dnsmasq`, `iproute2`, `tmux`

### Running the Wizard Interactively

```bash
# Clone the repository
git clone https://github.com/uosi/uosi.git
cd uosi

# Launch the wizard dispatcher on VT1
python3 -m core.engine
```

### Running with an Automated Configuration

To apply an existing JSON profile without interactive prompts:

```bash
python3 -m core.engine --apply-config /path/to/deployment-profile.json
```
