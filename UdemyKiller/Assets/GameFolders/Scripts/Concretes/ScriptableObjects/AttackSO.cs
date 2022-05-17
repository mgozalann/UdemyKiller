using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Combats;
using UdemyKiller.Combats;
using UnityEngine;

namespace UdemyKiller.ScriptableObjects
{
    enum AttackTypeEnum : byte
    {
        Range,Melee
    }


    [CreateAssetMenu(fileName = "Attack Info", menuName = "Attack Information/Create New", order = 51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] int _damage = 50;
        [SerializeField] float _floatValue = 1f;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _attackMaxDelay;
        [SerializeField] AttackTypeEnum _attackType;
        [SerializeField] AnimatorOverrideController animatorOverride;

        public int Damage => _damage;
        public float FloatValue => _floatValue;
        public LayerMask LayerMask => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;
        public AnimatorOverrideController AnimatorOverride => animatorOverride;
        public IAttackType GetAttackType(Transform transform)
        {
            if(_attackType == AttackTypeEnum.Range)
            {
                return new RangeAttackType(transform, this);
            }
            else
            {
                return new MeleeAttackType(transform, this);
            }
        }

    }
}
