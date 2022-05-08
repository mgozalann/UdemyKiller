using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Controllers;
using UnityEngine;

namespace UdemyKiller.Animations
{
    public class CharacterAnimation
    {
        Animator _animator;
        public CharacterAnimation(PlayerController playerController)
        {
           _animator = playerController.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if (_animator.GetFloat("moveSpeed") == moveSpeed) return;

            _animator.SetFloat("moveSpeed", moveSpeed,0.2f,Time.deltaTime);
        }
    }
}