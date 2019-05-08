###########################################
#### pseudo code - NOT A  SCRIPT ######
#################################
############################################
## pseudo code
#Run this file on server

#include what is necessary for the code to run.
### some configs...
listOfServersToBackup=readServerList()

foreach(listOfServers =>(server){
  if(checkconnectToServer(server)){
    mountServerForBackup(server)
    mountDedicateResourceForBackup(server)
    performServerSpecificBackup(server)
  
  }else{
    actionOnBackupStatusFail(server)
  }
}
}// end foreach
