using System;
using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Combats;
using UnityEngine;
using UnityEngine.UI;

namespace UdemyKiller.UIs
{
    public class DisplayHealth : MonoBehaviour
    {
        Image _healthImage;

        Health _health;

        private void Awake()
        {
            _healthImage = GetComponent<Image>();
        }

        private void OnEnable()
        {
            _health = GetComponentInParent<Health>();
            _health.OnTakeHit += HandleTakeHit;
        }

        private void OnDisable()
        {
            _health.OnTakeHit -= HandleTakeHit;
        }
        private void HandleTakeHit(int currentHealth, int maxHealth)
        {
            _healthImage.fillAmount = Convert.ToSingle(currentHealth) / Convert.ToSingle(maxHealth);
        }
    }
}
