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

        IMover _mover;
        IHealth _health;
        CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;
        InventoryController _inventory;

        Transform _playerTrans;

        private bool _canAttack;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>(); 
            _inventory = GetComponent<InventoryController>();
        }
        private void Start()
        {
            _playerTrans = FindObjectOfType<PlayerController>().transform;
        }
        private void Update()
        {
            if (_health.IsDead) 
            {
                _canAttack = false;
                return;
            }


            _mover.MoveAction(_playerTrans.transform.position, 10f);

            _canAttack = Vector3.Distance(_playerTrans.position, transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;
            
        }

        private void FixedUpdate()
        {
            if (_canAttack)
            {
                _inventory.CurrentWeapon.Attack();
            }
        }
        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
            _animation.AttackAnimation(_canAttack);
        }





    }

}
