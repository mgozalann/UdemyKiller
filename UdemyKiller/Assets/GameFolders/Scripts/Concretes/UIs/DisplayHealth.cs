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
            _health = GetComponentInParent<Health>();
        }
        private void Update()
        {
            _healthImage.fillAmount = (float)_health.CurrentHealth / _health.MaxHealth;
        }
    }
}
