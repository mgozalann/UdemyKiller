using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyKiller.Abstracts.Combats;
using UdemyKiller.ScriptableObjects;

namespace UdemyKiller.Combats
{
    public class RangeAttackType : MonoBehaviour, IAttackType
    {
        Camera _camera;
        AttackSO _attackSO;

        public RangeAttackType(Transform transformObj,AttackSO attackSO)
        {
            _camera = transformObj.GetComponent<Camera>();
            _attackSO = attackSO;

        }
        public void AttackAction()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);
            if (Physics.Raycast(ray, out RaycastHit hit, _attackSO.FloatValue, _attackSO.LayerMask))
            {
                if (hit.collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO.Damage);
                    Debug.Log("çalýþtý");
                }
            }
        }

    }

}