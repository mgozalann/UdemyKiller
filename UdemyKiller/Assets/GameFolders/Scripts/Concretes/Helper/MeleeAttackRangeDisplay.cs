using System.Collections;
using System.Collections.Generic;
using UdemyKiller.ScriptableObjects;
using UnityEngine;

namespace UdemyKiller.Helper
{
    public class MeleeAttackRangeDisplay : MonoBehaviour
    {
        [SerializeField] AttackSO _attackSO;
        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, _attackSO.FloatValue);
        }
    }

}
