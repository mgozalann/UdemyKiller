using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Movements;
using UdemyKiller.Controllers;
using UnityEngine;

namespace UdemyKiller.Movements
{
    public class RotatorY : MonoBehaviour, IRotator
    {
        Transform _transform;
        float _limit;
        public RotatorY(PlayerController playerController)
        {
            _transform = playerController.TurnTransform;
        }

        public void RotationAction(float direction, float speed)
        {
            direction *= speed * Time.deltaTime;
            _limit = Mathf.Clamp(_limit - direction,-30f,30f);
            _transform.localRotation = Quaternion.Euler(_limit, 0f, 0f);
            }
    }
}

