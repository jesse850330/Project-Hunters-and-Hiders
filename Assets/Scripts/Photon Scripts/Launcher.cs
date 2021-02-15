using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace HunterAndHider
{
    using Photon.Realtime;
    public class Launcher : MonoBehaviourPunCallbacks
    {
        [Tooltip("The maximum number of players in the lobby. When the number of players in the game lobby is full, new players can only open a new lobby to play the game.")]
        [SerializeField]
        private byte maxPlayersPerLobby = 4;
        string gameVersion = "1";

        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void Connect()
        {
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
            Debug.Log("PUN Call OnConnectedToMaster(), Connected Photon Cloud.");
            PhotonNetwork.JoinRandomRoom();
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("PUN Call OnDisconnected() {0}.", cause);
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions
            {
                MaxPlayers = maxPlayersPerLobby
            });
            Debug.Log("PUN Call OnJoinRandomFailed(), Joining Random Lobby Failed. None Lobby find, create new lobby.");
            PhotonNetwork.CreateRoom(null, new RoomOptions());
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Call OnJoinedRoom(), Joined Lobby.");
        }
    }
}
