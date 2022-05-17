using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyKiller.Inputs;
using UdemyKiller.Abstracts.Inputs;
using UdemyKiller.Abstracts.Movements;
using UdemyKiller.Movements;
using UdemyKiller.Animations;
using UdemyKiller.Abstracts.Controllers;

namespace UdemyKiller.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("Movement Informations")]
        [SerializeField] float _moveSpeed;
        [SerializeField] float _turnSpeed =10f;
        [SerializeField] Transform _turnTransform;

        public Transform TurnTransform => _turnTransform;


        IInputReader _input;
        IMover _mover;
        IRotator _xRotation;
        IRotator _yRotator;


        CharacterAnimation _animation; 

        Vector3 _direction;


        void Awake()
        {
            _input = GetComponent<IInputReader>();
            _xRotation = new RotatorX(this);
            _yRotator = new RotatorY(this);
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
        }
 
        void Update()
        {
            _direction = _input.Direction;

            _xRotation.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y, _turnSpeed);

            if (_input.IsAttackButtonPressed)
            {
                //_currentWeapon.Attack();
            }
        }

        private void FixedUpdate()
        {
            _mover.MoveAction(_direction,_moveSpeed);
           
        }
        private void LateUpdate()
        {
            _animation.MoveAnimation(Mathf.Abs(_direction.magnitude));
        }
    }

}
