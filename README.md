```markdown
# UOSI (Universal Operating System Installer)

A lightweight, modular, and pluggable Linux installation engine and bare-metal orchestration platform built on an Alpine Linux base. 

UOSI operates as a command-line and TUI wizard designed to install, deploy, rescue, or network-boot target Linux distributions (Debian, Ubuntu, RHEL/Rocky, Arch, Alpine, and custom rootfs targets) across local media, network storage backends, and local area networks.

---

## Key Architectural Principles

- **Minimal Footprint:** Runs from a minimal Alpine Linux environment with on-demand kernel module loading to minimize RAM consumption.
- **Concurrent VT & Remote Multiplexing:**
  - **VT1:** Interactive installer wizard.
  - **VT2:** Unrestricted root debug shell (inspect, partition, test without interrupting wizard state).
  - **VT3:** Live log aggregation sink.
  - **SSH Integration:** Multiplexed terminal sessions (`tmux`/`screen`) allowing remote operators to attach directly to the local installation session.
- **Passive-First Network Reconnaissance:** Discovers network topology (ARP, LLDP, existing DHCP offers, proxy services) prior to binding interfaces or starting server daemons.
- **Glitch-Free Cross-Distro Deployment:** Bridges the musl/glibc barrier by generating distribution-native post-install execution scripts injected directly into the target chroot environment.
- **Reproducible State Machine:** Exports and imports complete deployment plans via structured JSON profiles for replaying configurations and automated setups.
- **Hybrid Storage & Data Protection:** Enforces snapshot validation and triple-confirmation gates before performing destructive disk operations on complex volume layouts (LVM, Software RAID, Btrfs, ZFS).

---

## Operating Modes


```

UOSI Execution Engine
├── Mode-1: Network Boot Deployer (TFTP / PXE / BOOTP Appliance)
├── Mode-2: Ansible Network Orchestrator
├── Mode-3: Local Media / Native OS Installer
├── Mode-4: RootFS Tar Restorer (Special Crafted Image Unpacker)
├── Mode-5: Network Repository & Manifest Installer
└── Mode-6: Native Distribution Installer Passthrough (Kickstart / Preseed / Autoinstall)

```

### Mode Breakdown

* **Mode-1 (Network Boot Appliance):** Converts the running host into a temporary (in-memory) or permanent network boot server. Integrates with `BootpManager` to deliver BIOS/UEFI iPXE binaries, manage image repositories, enforce MAC-based admin authorization gates, or operate as a passive BOOTP monitor.
* **Mode-2 (Ansible Network Orchestrator):** Discovers online nodes across the local broadcast domain and applies remote execution playbooks.
* **Mode-3 (Normal OS Installer):** Form-factor-aware installer (laptop vs. server detection). Supports custom disk layouts, LVM + ext4, Btrfs subvolumes (`@rootfs`, `@home`), automated firewall (`nftables`) setup, SSH baseline hardening, and post-installation backup archive generation.
* **Mode-4 (RootFS Tar Restorer):** Restores raw system backups directly to partitioned storage, writes UUID-mapped `fstab` entries, rebuilds initramfs images, and installs target bootloaders (`grub`, `systemd-boot`).
* **Mode-5 (Network Repository Installer):** Pulls base package lists and manifests over HTTP/HTTPS/custom repositories to stage an installation directly to disk.
* **Mode-6 (Native Installer Passthrough):** Automates distribution-native installers via answersheets and pre-configurations (Debian Preseed, RHEL Kickstart, Ubuntu Subiquity).

---

## Project Structure

UOSI uses a micro-core architecture with decoupled, pluggable providers:


```

uosi/
├── build/                 # Alpine custom ISO and boot media build manifests
├── core/                  # Engine core
│   ├── engine.py          # State machine, step dispatcher, signal handlers
│   ├── session.py         # Thread-safe JSON state manager and journal
│   ├── hardware.py        # DMI heuristics, sysfs/PCI probe (on-demand kmod loader)
│   ├── network.py         # Passive sniffers (ARP/LLDP/DHCP), IP, and proxy managers
│   └── tui/               # Interface drivers (raw text CLI, curses/whiptail, Wayland)
├── providers/
│   ├── storage/           # Pluggable block and network storage drivers
│   │   ├── base.py        # Abstract storage interface
│   │   ├── lvm.py         # LVM volume group and logical volume operations
│   │   ├── btrfs.py       # Btrfs subvolume management and snapshot checks
│   │   ├── remote.py      # Network mounts: NFS, S3/FUSE, iSCSI, NBD, FCoE, Ceph RBD
│   │   └── dedup.py       # Binary delta/chunk-level deduplication handlers
│   └── targets/           # Distro-native chroot provisioning generators
│       ├── base.py        # In-chroot provisioning contract
│       ├── debian.py      # Debian/Ubuntu post-install script generator
│       ├── rhel.py        # RHEL/CentOS/Rocky post-install script generator
│       ├── arch.py        # Arch Linux post-install script generator
│       └── alpine.py      # Alpine Linux native script generator
└── modes/                 # User-facing execution wizards
├── mode1_pxe.py       # TFTP/PXE deployer logic
├── mode2_ansible.py   # Ansible orchestrator logic
├── mode3_install.py   # Native storage partitioning and OS extraction
├── mode4_restore.py   # RootFS archive deployment
├── mode5_netrepo.py   # HTTP repository streaming installation
└── mode6_native.py    # Kickstart/Preseed chainloader

```

---

## Storage & Hybrid Boot Media Support

UOSI boot media can be written to a hybrid USB drive layout compatible with both Windows and Linux hosts:

| Partition | Type | Filesystem | Description |
| :--- | :--- | :--- | :--- |
| **Partition 1** | Primary | **exFAT / NTFS** | Accessible on Windows. Stores raw ISOs, rootfs tarballs, and custom manifests. |
| **Partition 2** | ESP | **FAT32** | UEFI System Partition containing bootloaders (`BOOTX64.EFI`, iPXE). |
| **Partition 3** | Primary | **ext4 / SquashFS** | Alpine Linux root system containing the runtime engine and Python stack. |

### Remote Storage Backends Supported
- **Block:** Local NVMe/SATA, iSCSI, Ceph RBD, NBD, FCoE
- **File & Object:** NFS (v3, v4), CephFS, S3-compatible object stores (via FUSE)

---

## Getting Started

### Prerequisites
- Alpine Linux 3.19+ (or Docker builder container)
- Python 3.10+
- Core tools: `parted`, `e2fsprogs`, `btrfs-progs`, `dnsmasq`, `iproute2`, `tmux`

### Running the Wizard Locally

```bash
# Clone the project repository
git clone [https://github.com/](https://github.com/)<your-org>/uosi.git
cd uosi

# Launch the wizard dispatcher
python3 -m core.engine

```

To run with an automated JSON execution profile:

```bash
python3 -m core.engine --apply-config /path/to/deployment-profile.json

```

```

```
