using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyKiller.Abstracts.Movements;
using UdemyKiller.Abstracts.Controllers;
using UdemyKiller.Controllers;

namespace UdemyKiller.Movements
{
    public class MoveWithCharacterController : IMover
    {
        CharacterController _characterController;
        public MoveWithCharacterController(IEntityController entityController)
        {
            _characterController = entityController.transform.GetComponent<CharacterController>();
        }

        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            if (direction.magnitude == 0f) return;

            Vector3 worldPos = _characterController.transform.TransformDirection(direction);
            Vector3 movement = worldPos * moveSpeed * Time.deltaTime;
            _characterController.Move(movement);
        }
    }
}

