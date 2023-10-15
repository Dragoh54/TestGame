using System;
using UnityEngine;

namespace Resources.Scripts.Player
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        public float prLife;        //how much our projectile live
        
        private float _prCount;     //how much time projectile have
        private Rigidbody2D _rb;

        void Start()
        {
            _prCount = prLife;
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            _prCount -= Time.deltaTime;
            if (_prCount <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);
        }
    }
}
