# Challanges 

- non-image based backup
- efficient prep of sparse images
- network backup
- efficient utilisation of existing space on device
- handling of selinux/apparmor issues
- handling of disk partition definitions without imaging. fstab handling
- boot backup (mbr/efi). bsd/macos compatible
- integrate with /use as deployment and automation tool (ansible,chef,puppet,etc)
- robot and more
- incremental backup
- DR. DR Test procedure. DR procedure.
- ntfs read/restore including system backup.
- raid based / disk rotation backup.
- android x86 backup ?
- other issues regarding database files/on-memmory database backup. Snapshoting memory on disk ?
- archive encrypted folders/partition
- management of multiple systems. Keep configuration, track changes (for example adding new role to existing server, must update existing backup data)
- ...


# Requirments/Deliverables
## Input:
- what data to backup
 The user must be able to see and exclude some data from backup. For example video files, iso images and other large data can be excluded from backup and only documents/configuration or scripts must be included in backup.
 Also, database and other on-memory data must be backedup with specific tools
 Also, how encrypted data will be stored ?
 
- where to backup
  -- over the network
  -- on dedicated disk/tape/dvd
  
- what format to keep data in
  -- mounted archive ?
  -- sync folders with rsync/alternatves 
  -- protect encrypted data against unauthorized reading ?
  
  
## Output:
- existing data analyzer -> fstab content, files to exclude, files to include, other tools to run for sync, detect databases and other sensitive data like encrypted for example information.

- archive of data
- diff between previous existing data
- rotate plan
- DR Test Plan/Procedure
- ...

# When is required to use image-based backup. 
ddrescue. See the rescue part. 

# Similar tools:
https://github.com/tritonas00/system-tar-and-restore

