using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Controllers;
using UdemyKiller.Abstracts.States;
using UnityEngine;

namespace UdemyKiller.States.EnemyStates
{
    public class AttackState : IState
    {
        IEnemyController _enemyController;
        public AttackState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
        }
        public void OnExit()
        {
            _enemyController.Animation.AttackAnimation(false);
        }
        public void Tick()
        {
            //look at target
        }
        public void FixedTick()
        {
            _enemyController.Inventory.CurrentWeapon.Attack();
        }
        public void LateTick()
        {
            _enemyController.Animation.AttackAnimation(true);
        }
    }
}
