using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
   private  void Start()
    {
        Debug.Log("connecting");

        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("disconected");
    }
}
