using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Movements;
using UdemyKiller.Abstracts.Controllers;
using UnityEngine;
using UnityEngine.AI;


namespace UdemyKiller.Movements
{

    public class MoveWithNavMesh : IMover
    {
        NavMeshAgent _navMeshAgent;

        public MoveWithNavMesh(IEntityController entityController)
        {
             _navMeshAgent = entityController.transform.GetComponent<NavMeshAgent>();
        }
        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            _navMeshAgent.SetDestination(direction);
        }

    }

}
