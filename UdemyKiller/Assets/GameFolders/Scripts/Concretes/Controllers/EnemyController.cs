using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UdemyKiller.Abstracts.Controllers;
using UdemyKiller.Abstracts.Movements;
using UdemyKiller.Movements;
using UdemyKiller.Animations;
using UdemyKiller.Abstracts.Combats;

namespace UdemyKiller.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;

        IMover _mover;
        IHealth _health;
        CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
        }
        private void Update()
        {
            if (_health.IsDead) return;

            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }
        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
        }





    }

}
