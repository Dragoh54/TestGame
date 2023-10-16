using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ServerScripts
{
    public class SpawnCoins : MonoBehaviour
    {
        public GameObject coin;
        private GameObject _cloneCoin;
        public float minX, minY, maxX, maxY;

        private bool _isCollected;

        public void Start()
        {
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            _cloneCoin = PhotonNetwork.Instantiate(coin.name, spawnPosition, Quaternion.identity);
        }

        private void Update()
        {
            if (_cloneCoin.IsDestroyed())
            {
                Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                _cloneCoin = PhotonNetwork.Instantiate(coin.name, spawnPosition, Quaternion.identity);
            }
        }
    }
}
