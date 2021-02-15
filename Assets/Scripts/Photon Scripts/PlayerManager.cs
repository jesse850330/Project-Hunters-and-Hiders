using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;


    public class PlayerManager : MonoBehaviourPunCallbacks
    {
        [Tooltip("Player HP")]
        public float Health = 1f;
        
        bool IsFiring;

        void Start()
        {
            
            CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();

            if (_cameraWork != null)
            {
                if (photonView.IsMine)
                {
                    _cameraWork.OnStartFollowing();
                }
            }
            else
            {
                Debug.LogError("playerPrefab- CameraWork component lost", this);
            }
        }

        void Update()
        {
            if (Health <= 0f)
            {
                GameManager.Instance.LeaveRoom();
            }
        }
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(IsFiring);
                stream.SendNext(Health);
            }
            else
            {
                this.IsFiring = (bool)stream.ReceiveNext();
                this.Health = (float)stream.ReceiveNext();
            }
        }
    }

