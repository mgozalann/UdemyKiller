using System.Collections;
using System.Collections.Generic;
using UdemyKiller.Abstracts.Controllers;
using UdemyKiller.Controllers;
using UnityEngine;

namespace UdemyKiller.Animations
{
    public class CharacterAnimation
    {
        Animator _animator;
        public CharacterAnimation(IEntityController entity)
        {
           _animator = entity.transform.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if (_animator.GetFloat("moveSpeed") == moveSpeed) return;

            _animator.SetFloat("moveSpeed", moveSpeed,0.2f,Time.deltaTime);
        }

        public void AttackAnimation(bool isAttack)
        {
            _animator.SetBool("isAttack", isAttack);
        }
    }
}
