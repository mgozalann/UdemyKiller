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

        int _currentHealth;
        int _maxHealth;
        public int MaxHealth => _maxHealth;
        public bool IsDead => _currentHealth <= 0;
        public int CurrentHealth => _currentHealth;

        private void Awake()
        {
            _maxHealth = _healthInfo.MaxHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (IsDead) return;

            _currentHealth -= damage;

        }
    }

}
