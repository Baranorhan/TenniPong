using System;
using Photon.Pun;
using UnityEngine;

public class NetChecker : MonoBehaviourPunCallbacks 
{
    [HideInInspector]public bool Ismine;
    private void Awake() {
        
        Ismine = (photonView.IsMine == true && PhotonNetwork.IsConnected == true);
        
    }
    
}