using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UdemyKiller.Abstracts.Controllers;
using UdemyKiller.Abstracts.Movements;
using UdemyKiller.Movements;
using UdemyKiller.Animations;
using UdemyKiller.Abstracts.Combats;
using UdemyKiller.States;
using UdemyKiller.States.EnemyStates;

namespace UdemyKiller.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        StateMachine _stateMachine;
        NavMeshAgent _navMeshAgent;

        IHealth _health;
        public bool CanAttack =>
            Vector3.Distance(Target.position, transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;
        public IMover Mover { get; private set; }
        public InventoryController Inventory { get; private set; }
        public CharacterAnimation Animation { get; private set; }
        public Transform Target { get; set; }
        public float Magnitude => _navMeshAgent.velocity.magnitude;

        private void Awake()
        {
            Inventory = GetComponent<InventoryController>();
            Mover = new MoveWithNavMesh(this);
            Animation = new CharacterAnimation(this);

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _stateMachine = new StateMachine();
        }
        private void Start()
        {
            Target = FindObjectOfType<PlayerController>().transform;

            AttackState attackState = new AttackState(this);
            ChaseState chaseState = new ChaseState(this);
            DeadState deadState = new DeadState(this);

            _stateMachine.AddState(attackState, chaseState, () => CanAttack);
            _stateMachine.AddState(chaseState, attackState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);

            _stateMachine.SetState(chaseState);

        }
        private void Update()
        {
            _stateMachine.Tick();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedTick();
        }
        private void LateUpdate()
        {
            _stateMachine.LateTick();
        }
    }
}
