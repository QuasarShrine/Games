using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{

    public void MyStartHOST() {
        Debug.Log(Time.timeSinceLevelLoad + "Start hosting at : ");
        StartHost();
    }

    public override void OnStartHost() {
        Debug.Log(Time.timeSinceLevelLoad + "Host started at : ");
    }

    public override void OnStartClient(NetworkClient myClient) {
        Debug.Log(Time.timeSinceLevelLoad + " Client Started");
        InvokeRepeating("printsDots",0f,1f);
    }
    public override void OnClientConnect(NetworkConnection myConnection) {
        Debug.Log(Time.timeSinceLevelLoad + " Client Connected | clientid : " + myConnection.connectionId);
        CancelInvoke("PrintsDots");
    }

    public void PrintsDots() {
        Debug.Log('.');
    }
}
