UOSI
====

This is an universal OS installer targeting linux and bsd like distributions.

Planning stage

It is required because i found  fedora has no options for what i need for, arch os neither.

Each distribution has his own installer but i feel uncomfortable with the install os and choices.

Inspired from debian , manjaro, ubuntu, archlinux and others

# Target
- System Automation
- Server deployment automation (CloudStack, OpenStack, xen-based hypervisors, maas)

# Prerequisites for local build
-a working linux distribution with bash/php/python/perl scripts
- the script will create a root archive for deployment using specified distribution. If internet connection is available
-- @todo allow deploy of the archive as 
- the output could be 
-- rootfs as tar.gz image for deployment on 
-- an iso/usbimg with automated script to deploy on boot
-- an prep/deployer iso for network boot via nfs, configurable on role (roothost, bootonly), instalable



# @Todo -> Online builder
Some modules will be available to be deployed from a site. The script will create a task on the server and will inform the requester by email on completion. Undownloaded tasks will be deleted on 24h schedule.
User input:
 - source distribution and version (autoupdate from distro site)
 - output mode (rootfs, autoinstall for iso|usbimage, prep distro (dhcp+tfs for boot))
 -captcha
 -email to receive result

More option for each output will come.

The module can  be deployed on premise/cloud/etc.
# Enterprise version

This module will allow the online /deployable server  to be used in an enterprise environment
