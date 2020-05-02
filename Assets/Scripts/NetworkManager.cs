using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [System.Serializable]
    public class MPGameobj
    {
        public GameObject Host;
        public GameObject ball;
        public GameObject Client;

    }
    [System.Serializable]
    public class UiObj
    {
        public GameObject LoginMenu;
        public GameObject LoadingScreen;
        public Image Spinner;
        public float SpinnerRotationSpeed;
        public GameObject WaitingForPlayer;

    }
    public MPGameobj mpGameobj = new MPGameobj();
    public UiObj uiObj = new UiObj();
   
    private bool isHost = false;

    private void Start()
    {
        Debug.Log("connecting");
        PhotonNetwork.NickName = "deneme " + Random.Range(0, 999).ToString();
        PhotonNetwork.GameVersion = "0.0.1";

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;

    }
    void Update()
    {
        uiObj.Spinner.rectTransform.Rotate(Vector3.forward * (uiObj.SpinnerRotationSpeed * Time.deltaTime));
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        PhotonNetwork.AutomaticallySyncScene = true;
        uiObj.LoginMenu.SetActive(true);
        uiObj.LoadingScreen.SetActive(false);

    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("disconected");
    }

    public void JoinGameTenni()
    {
        uiObj.LoginMenu.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            Debug.Log("problem");
        }

    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom("deneme", new RoomOptions { MaxPlayers = 2 });

    }
    public override void OnCreatedRoom()
    {
        Debug.Log("created.");
        PhotonNetwork.Instantiate(mpGameobj.Host.name, new Vector3(-7f, 0f, 0f), Quaternion.identity, 0);
        isHost = true;
        uiObj.LoadingScreen.SetActive(true);
        uiObj.WaitingForPlayer.SetActive(true);

    }

    public override void OnJoinedRoom()
    {
        if (!isHost)
            PhotonNetwork.Instantiate(mpGameobj.Client.name, new Vector3(7f, 0f, 0f), Quaternion.identity, 0);

        Debug.Log("joined.");

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        uiObj.LoadingScreen.SetActive(false);
        uiObj.WaitingForPlayer.SetActive(false);

        PhotonNetwork.Instantiate(mpGameobj.ball.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);

        Debug.Log(newPlayer);
    }
}
