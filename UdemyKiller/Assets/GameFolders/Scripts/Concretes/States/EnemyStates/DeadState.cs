using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Controllers;
using UdemyKiller.Abstracts.States;
using UnityEngine;

namespace UdemyKiller.States.EnemyStates
{
    public class DeadState : IState
    {
        IEnemyController _enemyController;
        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            Debug.Log("öldü");
        }
        public void OnExit()
        {
        }
        public void Tick()
        {

        }
        public void FixedTick()
        {
        }
        public void LateTick()
        {
        }
    }

}
