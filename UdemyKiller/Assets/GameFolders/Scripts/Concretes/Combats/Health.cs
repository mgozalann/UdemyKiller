using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Combats;
using UdemyKiller.ScriptableObjects;
using UnityEngine;

namespace UdemyKiller.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] HealthScriptableObject _healthInfo;
        public bool IsDead => _currentHealth <= 0;

        int _currentHealth;



        private void Awake()
        {
            _currentHealth = _healthInfo.MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (IsDead) return;

            _currentHealth -= damage;
        }
    }

}
