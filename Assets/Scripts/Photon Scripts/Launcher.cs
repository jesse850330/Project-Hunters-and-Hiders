using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher: MonoBehaviourPunCallbacks
{
    bool isConnecting;

    [Tooltip("Show/Hide Menu")]
    [SerializeField]
    private GameObject controlPanel;

    [Tooltip("Show/Hide Connecting")]
    [SerializeField]
    private GameObject progressLabel;

    [Tooltip("The maximum number of players in the lobby. When the number of players in the game lobby is full, new players can only open a new lobby to play the game.")]
    [SerializeField]
    private byte maxPlayersPerRoom = 10;

    string gameVersion = "1";

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
    }

    public void Connect()
    {
        isConnecting = true;

        progressLabel.SetActive(true);
        controlPanel.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        } 

        Debug.Log("PUN Call OnConnectedToMaster(), Connected Photon Cloud.");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);

            Debug.LogWarningFormat("PUN Call OnDisconnected() {0}.", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Call OnJoinRandomFailed(), Joining Random Lobby Failed. None Lobby find, create new lobby.");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("First Player");
            Debug.Log("Load MainLobby");
            PhotonNetwork.LoadLevel("MainLobby");
        }
        
        Debug.Log("PUN Call OnJoinedRoom(), Joined Lobby.");
    }
}