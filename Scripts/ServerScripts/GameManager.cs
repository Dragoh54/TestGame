using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ServerScripts
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public GameObject player;
        public float minX, minY, maxX, maxY;
        
        private PhotonView _view;

        public void Start()
        {
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            PhotonNetwork.Instantiate(player.name, spawnPosition, Quaternion.identity);
        }

        public void Leave()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }
    }
}
