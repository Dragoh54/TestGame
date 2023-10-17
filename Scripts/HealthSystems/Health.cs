using UnityEngine;

namespace HealthSystems
{
    public class Health : MonoBehaviour
    {
        public float maxHealth;
        private float _hp;

        public RectTransform healthBar;
        void Start()
        {
            _hp = maxHealth;
        }

        public void TakeDamage(float amount)
        {
            _hp -= amount;
            if (_hp <= 0)
            {
                _hp = 0;
                Debug.Log("Died");
            }

            healthBar.sizeDelta = new Vector2(_hp, healthBar.sizeDelta.y);
        }
    }
}
