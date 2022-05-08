using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Movements;
using UdemyKiller.Controllers;
using UnityEngine;

namespace UdemyKiller.Movements
{
    public class RotatorX : MonoBehaviour, IRotator
    {
        PlayerController _playerController;
        public RotatorX(PlayerController playerController)
        {
             _playerController = playerController;
        }
         
        public void RotationAction(float direction,float speed)
        {
            _playerController.transform.Rotate(Vector3.up * direction * speed * Time.deltaTime);
        }
    }
}
