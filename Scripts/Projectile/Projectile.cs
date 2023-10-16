using System;
using HealthSystems;
using UnityEngine;
using Photon.Pun;


namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        public float prLife;        //how much our projectile live
        
        private float _prCount;     //how much time projectile have
        private Rigidbody2D _rb;
        private Vector3 _moveVector;
        
        private Joystick _joystick;
        
        void Start()
        {
            _prCount = prLife;
            _rb = GetComponent<Rigidbody2D>();
            _joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>();
            _moveVector = Vector3.up * _joystick.Vertical - Vector3.left * _joystick.Horizontal;
            _moveVector.Normalize();
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
            _rb.velocity = new Vector2(_moveVector.x * speed, _moveVector.y * speed);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            GameObject hit = other.gameObject;
            Health health = hit.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(1);
            }
            
            Destroy(gameObject);
        }
    }
}
