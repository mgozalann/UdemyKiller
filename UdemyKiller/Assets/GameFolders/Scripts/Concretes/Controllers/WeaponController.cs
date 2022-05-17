using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Combats;
using UdemyKiller.Combats;
using UdemyKiller.ScriptableObjects;
using UnityEngine;

namespace UdemyKiller.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;
        [SerializeField] Transform _transformObj;

        [SerializeField] AttackSO _attackSO;

        public AttackSO AttackSO => _attackSO;
        IAttackType _attackType;

        float _currentTime;

        private void Awake()
        {
            _attackType = _attackSO.GetAttackType(_transformObj);
        }
        private void Update()
        {
            _currentTime += Time.deltaTime;
            _canFire = _currentTime > _attackSO.AttackMaxDelay;
        }

        public void Attack()
        {
            if (!_canFire) return;
            
            _attackType.AttackAction();

            _currentTime = 0;
        }


    }

}
