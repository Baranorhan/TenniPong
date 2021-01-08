using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [System.Serializable]
    public class MpGameobjectClass// Multi player game objects
    {
        public GameObject host;
        public GameObject ball;
        public GameObject client;

    }
    [System.Serializable]
    public class UiObj
    {
        public GameObject loginMenu;
        public GameObject loadingScreen;
        public Image spinner;
        public float spinnerRotationSpeed;
        //TODO public GameObject waitingForPlayer;

    }
    [SerializeField] private MpGameobjectClass mpGameobjects = new MpGameobjectClass();
    [SerializeField] private UiObj _uiObj = new UiObj();
    [SerializeField] private GameManager gameManager;
    private GameObject _left, _right, _ball;
    private bool _isHost = false;

    private void Start()
    {
        Debug.Log("connecting");
        PhotonNetwork.NickName = "Try " + Random.Range(0, 999).ToString();
        PhotonNetwork.GameVersion = "0.0.1";
    if(!PhotonNetwork.IsConnected)
        PhotonNetwork.ConnectUsingSettings();
    else
    {
        _uiObj.loginMenu.SetActive(true);
        _uiObj.loadingScreen.SetActive(false);
    }
        PhotonNetwork.AutomaticallySyncScene = true;

    }
    void Update() 
    {
        _uiObj.spinner.rectTransform.Rotate(Vector3.forward * (_uiObj.spinnerRotationSpeed * Time.deltaTime));
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        PhotonNetwork.AutomaticallySyncScene = true;
        _uiObj.loginMenu.SetActive(true);
        _uiObj.loadingScreen.SetActive(false);

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        
    }

    public void JoinGameTenni()
    {
        _uiObj.loginMenu.SetActive(false);

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
        _left = PhotonNetwork.Instantiate(mpGameobjects.host.name,
        new Vector3(-7f, 0f, 0f), Quaternion.identity, 0);
        _isHost = true;
        _uiObj.loadingScreen.SetActive(true);

    }

    public override void OnJoinedRoom()
    {
        if (!_isHost)
           _right = PhotonNetwork.Instantiate(mpGameobjects.client.name, 
         new Vector3(7f, 0f, 0f), Quaternion.identity, 0);
        Invoke("SendPlayerandBall",1f);

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        _uiObj.loadingScreen.SetActive(false);
        Invoke("SendPlayerandBall",1f);

        _ball = PhotonNetwork.Instantiate(mpGameobjects.ball.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
    }

    private void SendPlayerandBall()
    {
        gameManager.SetPlayersandBall();
    }
}
