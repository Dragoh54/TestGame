using System;
using Photon.Pun;
using ServerScripts;
using UnityEngine;
using TMPro;

namespace Coin
{
    public class CoinCollector : MonoBehaviour
    {
        private int _coinCounter;
        private PhotonView _view;
        
        private GameObject _text;

        private void Start()
        {
            _coinCounter = 0;
            _view = GetComponentInParent<PhotonView>();
            _text = GameObject.FindWithTag("Counter");
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                PhotonNetwork.Destroy(other.gameObject);
                _coinCounter++;
                _view.RPC("UpdateCoinCount", RpcTarget.AllBuffered, _coinCounter);
            }
        }
        
        [PunRPC]
        void UpdateCoinCount(int newCount)
        {
            _coinCounter = newCount;
        }
    }
}
