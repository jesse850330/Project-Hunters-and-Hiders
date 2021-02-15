using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [Tooltip("Prefab- Player Character")]
    public GameObject playerPrefab;

    public static GameManager Instance;

    void Start()
    {
        Instance = this;

        if (playerPrefab == null)
        {
            Debug.LogError("playerPrefab lost, Please reset in Game Manager",this);
        }
        else
        {
            Debug.LogFormat("Spawn Player Character {0}", Application.loadedLevelName);
            PhotonNetwork.Instantiate(this.playerPrefab.name, 
            new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        }
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("Not Master Client, Do not load scene");
        }

        Debug.LogFormat("Load{0}Scene", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel("MainLobby");
    }   

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("{0} Join Lobby", other.NickName);

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("Is Master Client? {0}", PhotonNetwork.IsMasterClient);
            LoadArena();
        }
    }

    public override void OnPlayerLeftRoom(Player other)
    {  
        Debug.LogFormat("{0} Leave Lobby", other.NickName);

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("Is Master Client? {0}", PhotonNetwork.IsMasterClient);
            LoadArena();
        }
    }
}