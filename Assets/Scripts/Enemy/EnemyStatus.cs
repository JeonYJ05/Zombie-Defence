using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace YJ.Zombie.Enemy
{
    public class EnemyStatus : MonoBehaviour
    {
        public float MaxHealth = 100f;
        public float _currentHealth;
        public Image HealthBar;
        private bool _isDeath = false;
        private EnemyMove _move;
        private CapsuleCollider _colider;
        
        


        public float CurrentHealth { get { return _currentHealth; } }

        private void Start()
        {
            _move = GetComponent<EnemyMove>();
            _colider = GetComponent<CapsuleCollider>();
            _currentHealth = MaxHealth;
            
        }

        public void TakeDamage(float damage)
        {
            if (_isDeath)
                return;
            _currentHealth -= damage;
            HealthBar.fillAmount = _currentHealth / MaxHealth;
            
            // �ǰ� �ִϸ��̼�
            if (_currentHealth <= 0f)
            {
                Death();
            }
            Debug.Log($"������ �� :" + _currentHealth);
        }

        public void Death()
        {
            _isDeath = true;
            // �״� �ִϸ��̼�
            _move.enabled = false;
            _colider.enabled = false;
            DestroyEnemy();
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject, 2f);
        }

       // private void Update()
       // {
       //     _hpSlider.transform.position = transform.position;
       // }
    }
    
}