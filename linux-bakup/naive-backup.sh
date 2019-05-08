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
    resource1=mountServerForBackup(server)
    resource2=mountDedicateResourceForBackup(server)
    performServerSpecificBackup(server,resource1,resource2)
  
  }else{
    actionOnBackupStatusFail(server)
  }
}
}// end foreach

performServerSpecificBackup(server, sourceOfBackup, destinationOfBackup){
      listOfResources=getListOfWhatisNeededToBackup(server)
      callback=getBackupMethod(server);
      backupstatus=getAndExecuteScriptFor(callback,listOfResources,resource1, resource2);
}
