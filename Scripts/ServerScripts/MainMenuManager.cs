using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using Random = UnityEngine.Random;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviourPunCallbacks
    {
        public GameObject playerName;
        public GameObject createRoom;
        public GameObject joinRoom;

        private void Start()
        {
            PhotonNetwork.NickName = "Player " + Random.Range(1, 9999);
        }

        public void SetNickName()
        {
            var nickName = playerName.GetComponent<TMP_InputField>().text;
            PhotonNetwork.NickName = nickName;
        }

        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions
            {
                MaxPlayers = 4
            };
            
            PhotonNetwork.CreateRoom(createRoom.GetComponent<TMP_InputField>().text, roomOptions);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(joinRoom.GetComponent<TMP_InputField>().text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }
}