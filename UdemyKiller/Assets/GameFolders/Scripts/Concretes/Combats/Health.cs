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
        public bool IsDead => _currentHealth <= 0;
        public event System.Action<int, int> OnTakeHit;

        private void Awake()
        {
            _currentHealth = _healthInfo.MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            Debug.Log(IsDead);
            if (IsDead) return;
            _currentHealth -= damage;
            OnTakeHit?.Invoke(_currentHealth, _healthInfo.MaxHealth);
        }
    }

}
