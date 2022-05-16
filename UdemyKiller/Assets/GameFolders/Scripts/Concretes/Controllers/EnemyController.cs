using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UdemyKiller.Abstracts.Controllers;
using UdemyKiller.Abstracts.Movements;
using UdemyKiller.Movements;
using UdemyKiller.Animations;

namespace UdemyKiller.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;

        IMover _mover;
        CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }
        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
        }





    }

}
