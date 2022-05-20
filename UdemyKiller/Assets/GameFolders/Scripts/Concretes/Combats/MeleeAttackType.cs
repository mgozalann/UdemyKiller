using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Combats;
using UdemyKiller.ScriptableObjects;
using UnityEngine;

namespace UdemyKiller.Combats
{
    public class MeleeAttackType : MonoBehaviour, IAttackType
    {
        Transform _transformObj;
        AttackSO _attackSO;

        public MeleeAttackType(Transform transformObj,AttackSO attackSO)
        {
            _transformObj = transformObj;
            _attackSO = attackSO;
        }
        public void AttackAction()
        {
            Vector3 attackPoint = _transformObj.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint, _attackSO.FloatValue, _attackSO.LayerMask);
            foreach (Collider collider in colliders)
            {
                if(collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO.Damage);
                }
            }
        }
    }

}
