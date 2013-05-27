using System;
using System.Collections.Generic;
using System.Text;

namespace ro.integrator.os.installer
{

    public class DebugMessages{
        public String DbgMsg0000_0001="Getting bios information";
        public String DbgMsg0000_0002="Identifying cpu";
        public String DbgMsg0000_0003="Measuring memory";
        public String DbgMsg0000_0004="Detecting storages based on bios and kernel detection";
        public String DbgMsg0000_0005="Found HD:";
        public String DbgMsg0000_0006="Found HDUSB:";
        public String DbgMsg0000_0007="Found DVD/CDROM:";
        public String DbgMsg0000_0008="Error:";
        public String DbgMsg0000_0009="Detecting network devices";
        public String DbgMsg0000_000A="Found LAN adapter";
        public String DbgMsg0000_000B="Found WIFI adapter";

        public String DbgMsg0000_000C = "Connectiong to network";
        public String DbgMsg0000_000D = "Connectiong to access point using password";
        public String DbgMsg0000_000E = "Network already connected. Skiping";


        


    }
    public class InstallerMessages
    {
        #region start
        public String Welcome="Hello";
        public String ChooseStage1Message0000_0000_0 = "This installer is able to install this local distributions(select one)(more...)";
        public String ChooseStage1Message0000_0000_0 = "This installer is able to live boot this distributions(select one)(more...)";

        public String ChooseStage1Label1_0="Enable log ?";
         public String ChooseStage1Label1_2="Record actions for scripted installation?";
        public String ChooseStage1Label1_1="Show log ?";
        public String ChooseStage1Message0000_0001=@"Please select log options\r\n If you enable log, a log file will be writen containing installer process traces. If show log if enabled, after each operation you will see the log of executed operations If record actions enabled, a script will be generated to help you perform same operations automaticaly next time.";
        public String ChooseStage1AdvancedConfigLabel0001 = "Enable update stage from local media";
        public String ChooseStage1AdvancedConfigLabel0002 = "Enable update stage from network";
        public String ChooseStage1AdvancedConfigLabel0003 = "Enable update installer from local media";
        public String ChooseStage1AdvancedConfigLabel0004 = "Enable update installer from network";
        public String ChooseStage1AdvancedConfigLabel0005 = "Enable install other distrib from media";
        public String ChooseStage1AdvancedConfigLabel0006 = "Enable install other distrib from network";
        public String ChooseStage1AdvancedConfigLabel0007 = "Disable install modules from local media"; // default enabled
        public String ChooseStage1AdvancedConfigLabel0008 = "Enable install modules from network";
        


        public String ChooseStage1Message0000_0002="Do you have support ?";
        public String ChooseStage1Label0000_0002_0="Username(email address)";
        public String ChooseStage1Label0000_0002_1="Password";
        #endregion
        #region hwdetect
        public String ChooseStage1Message0000_0003_0="Do you want to load additional modules from media ?";
        public String ChooseStage1Label0000_0003_0_0="Select media containing module to load";
        public String ChooseStage1Label0000_0003_0_1="Select module file to load(browse)";

        public String ChooseStage1Message0000_0003_1="Network detected.Do you want to configure network ?";
        public String ChooseStage1Message0000_0003_1_0="Please choose the interface to configure";
        public String ChooseStage1Message0000_0003_1_1="Use DHCP?";
        public String ChooseStage1Message0000_0003_1_2="Enter accesspoint name or select from list";
        public String ChooseStage1Message0000_0003_1_3="Select access point encryption method";
        public String ChooseStage1Message0000_0003_1_4="Select access point password";
        /// <summary>
        /// todo dialup
        /// </summary>
        public String ChooseStage1Message0000_00003_1_ppp="PPP not available at this time.Falling to local media";


        public String ChooseStage1Message0000_0003_2 = "Hardware detection completed(...more)";
        public String ChooseStage1Message0000_0003_2="Do you want to load additional modules from network ?";
        public String ChooseStage1Label0000_0003_2_1="Insert the url of module list to load (or use default provided)";
        public String ChooseStage1Label0000_0003_2_2="Select module to load(select from list)";
        public String ChooseStage1Message0000_0003_3="Do you want to load additional modules from new detected hardware(restart stage 1 ) ?";

        #endregion

        #region detect installer updates

        public String ChooseStage1Message0000_0004_0 = "Searching for installer updates";
        public String ChooseStage1Message0000_0004_A = "Prepare a boot media (usb | cdrom )";
        public String ChooseStage1Message0000_0004_1 = "No updates find. Do you want to search in specific location?";
        public String ChooseStage1Message0000_0004_2 = "Do you like to try to download installer updates from internet ?";
        public String ChooseStage1Message0000_0004_3 = "Enter the mirror to use or select one from list";
        public String ChooseStage1Message0000_0004_4 = "New mirror list found. Use this ?";
        public String ChooseStage1Message0000_0004_5 = "Installer update find. Use this?";
        #endregion

        #region localmedium detect
        public String ChooseStage1Message0000_0005_0 = "Starting selected installer...";
        public String ChooseStage1Message0000_0005_6 = "Update local stages?";
        public String ChooseStage1Message0000_0005_7 = "Set local stages mirror or select one";

        public String ChooseStage1Message0000_0005_1 = "The installer is able to install using the curent media or install other  distribution.";
        public String ChooseStage1Message0000_0005_2 = "Scanning for iso or other usable media files";
        public String ChooseStage1Message0000_0005_3 = "Load config from web ?";
        public String ChooseStage1Message0000_0005_4 = "Found a new list from web";
        public String ChooseStage1Message0000_0005_5 = "Installer update find. Use this?";
        #endregion

        #region partitioning
        public String ChooseStage1Message0000_0006_00 = "The folowing storage was detected(...more)";
        public String ChooseStage1Message0000_0006_01 = "Create a raw file for storage";
        public String ChooseStage1Message0000_0006_02 = "Select raw file format";
        public String ChooseStage1Message0000_0006_03 = "Partitioning raw hdd file";

        public String ChooseStage1Message0000_0006_04 = "Select a storage for instalation";
        public String ChooseStage1Message0000_0006_05 = "Detected partitions on storage";
        public String ChooseStage1Message0000_0006_06 = "The system will be installed to raw file partition -iso";
        public String ChooseStage1Message0000_0006_07 = "The system will be installed to raw file partition -hddimage";
        public String ChooseStage1Message0000_0006_08 = "Do not install, just prepare for boot from selected medium/file with live system";
        public String ChooseStage1Message0000_0006_0H = "Mount nfs | fc | ataoe | iscsi |llvm |raid| ?";

        public String ChooseStage1Message0000_0006_09 = "Where the target  will be mounted ?";
        public String ChooseStage1Message0000_0006_0A = "Create cpio/cramfs mount point";
        public String ChooseStage1Message0000_0006_0B = "Select target mountpoint";
        public String ChooseStage1Message0000_0006_0C = "Format partition?";
        public String ChooseStage1Message0000_0006_0D = "Create swap partition ";
        public String ChooseStage1Message0000_0006_0E = "Fix partition order";
        public String ChooseStage1Message0000_0006_0F = "Apply configuration";
        public String ChooseStage1Message0000_0006_0G = "Run external partition manager";

        public String ChooseStage1Message0000_0006_0I = "Where to install bootloader (...more)";
        public String ChooseStage1Message0000_0006_0ILabel = "Do not install bootloader";
        public String ChooseStage1Message0000_0006_0J = "Select bootloader";
        public String ChooseStage1Message0000_0006_0KLabel = "Install generic or this sistem detected only modules ?";

        public String ChooseStage1Message0000_0006_0L = "Create new user?";
        public String ChooseStage1Message0000_0006_0LLabel = "Sudo ?";
        public String ChooseStage1Message0000_0006_0M = "Set locale";
        public String ChooseStage1Message0000_0006_0N = "Set time";
        public String ChooseStage1Message0000_0006_0NLabel = "Use ntp sync ?";


        #endregion
#region install
        public String ChooseStage1Message0000_0007_00 = "Generating install script ";
        public String ChooseStage1Message0000_0007_01 = "Do you want to edit install script to perform manual adjustments ?";
        public String ChooseStage1Message0000_0007_02 = "Test install script (non-destructive ) ";
        public String ChooseStage1Message0000_0007_03 = "Switching to perform install ";

        public String CommitStage1Message0000_0001_00 = "Reading install script ";
        public String CommitStage1Message0000_0001_01 = "Performing partitioning as required ";
        public String CommitStage1Message0000_0001_02 = "Mounting targets ";
        public String CommitStage1Message0000_0001_03 = "Mounting sources ";
        public String CommitStage1Message0000_0001_04 = "Using local sources";
        public String CommitStage1Message0000_0001_05 = "Using local selected sources";
        public String CommitStage1Message0000_0001_06 = "Install base system";
        public String CommitStage1Message0000_0001_07 = "Install system";
        public String CommitStage1Message0000_0001_08 = "Install additional sofware";
        public String CommitStage1Message0000_0001_09 = "Load online repositories";

        public String CommitStage1Message0000_0001_0A = "Downloading stages update";
        public String CommitStage1Message0000_0001_0B = "Downloading distribution iso";

        public String CommitStage1Message0000_0001_0C = "Chrooting to new installed distribution";
        public String CommitStage1Message0000_0001_0D = "Chrooting to boot media installation";
        public String CommitStage1Message0000_0001_0E = "Installing bootloader";

        public String CommitStage1Message0000_0001_0E = "Performing postinstall steps";

        public String CommitStage1Message0000_0001_0F = "Script complete.";

        public String CommitStage1Message0000_0001_0G = "Saving install script to";
        public String CommitStage1Message0000_0001_0H = "Please select a location to save install script";


#endregion
         




        public String LabelGoToStage = "Go to specific stage";

        public String Wait="Please wait";
        public String WaitChar="...";
        public String Stage1DetectingHw="Detecting local hardware";

        
       
        public String Stage1Detection="Found the folowing medium with installers";
        public String Stage1Detection2="Please select one to continue";
        public String Stage1Detection3="Found the folowing medium with installers";



        public static InstallerMessages En
        {
            get
            {
                return InstallerMessages.En;
            }
            set
            {
            }
        }
    }

    public class LocalizationInstallerMessagesList
    {
        public Dictionary<String, InstallerMessages> LangSet = new Dictionary<string, InstallerMessages>()
        {
            {"en",InstallerMessages.En}
        };
    }
    public interface IStage
    {
        /// <summary>
        /// every stage has a title 
        /// as everything has a beginning
        /// </summary>
        /// <returns></returns>
        String GetStageTitle();
        String GetStageParametersName();

    }

    /// <summary>
    /// first detect low level hardware -> procesors, memory, hdd, dvd, usb,  efi, remap if required,
    /// next detect installer source and medium
    /// next choose installer sources -> it can install another os than intended (like unetbootin ;)
    /// choose undetected source from local media or continue
    /// next detect network links or/and configure network
    /// next choose network repository , network source or network mirrors 
    /// next check for installer update -> do update or use current installer
    /// next check for media update if required
    /// next prepare local storage -> commit local storage setup
    /// next download from internet required packages 
    /// 
    /// </summary>
    /// 
/*
 * */


    /// <summary>
    /// first detect low level hardware -> procesors, memory, hdd, dvd, usb,  efi, remap if required,
    /// next detect installer source and medium
    /// ChooseNetwork;Select NetUrls
    /// IfUpdateexists ask to download repositoryes
    /// List default repository from local
    /// Get other repositoryes from local
    /// 
    /// next check for media update if required
    /// next prepare local storage -> commit local storage setup
    /// next download from internet required packages 
    /// 
    ///
    /// </summary>
    protected class OrderInstallFromNetRepository
    {
        
    }

    /// <summary>
    /// just decompress base.stage and existing other stage to selected partition/s
    /// </summary>
    protected class OrderInstallFromLocalSystemStages 
    {
    }
}
