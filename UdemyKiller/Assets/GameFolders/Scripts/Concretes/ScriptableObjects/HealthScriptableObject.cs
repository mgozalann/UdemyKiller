using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyKiller.ScriptableObjects
{
    [CreateAssetMenu(fileName = "HealthInfo",menuName = "HealthInformation/Create New",order =51)]
    public class HealthScriptableObject : ScriptableObject
    {
        [SerializeField] int _maxHealth;

        public int MaxHealth => _maxHealth;
    }

}
