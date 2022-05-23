using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Controllers;
using UdemyKiller.Abstracts.States;
using UnityEngine;

namespace UdemyKiller.States.EnemyStates
{
    public class ChaseState : IState
    {
        float speed = 10f;
        IEnemyController _enemyController;
        public ChaseState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
        }
        public void OnExit()
        {    

        }
        public void Tick()
        {
            _enemyController.Mover.MoveAction(_enemyController.Target.position, speed);
        }
        public void FixedTick()
        {
        }
        public void LateTick()
        {
            _enemyController.Animation.MoveAnimation(_enemyController.Magnitude);
        }
    }

}
