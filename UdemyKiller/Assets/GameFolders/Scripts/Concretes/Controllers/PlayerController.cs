using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyKiller.Inputs;
using UdemyKiller.Abstracts.Inputs;
using UdemyKiller.Abstracts.Movements;
using UdemyKiller.Movements;
using UdemyKiller.Animations;

namespace UdemyKiller.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Informations")]
        [SerializeField] float _moveSpeed;

        IInputReader _input;
        IMover _mover;
        CharacterAnimation _animation; 

        Vector3 _direction;

        void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
        }

        // Update is called once per frame
        void Update()
        {
            _direction = _input.Direction;
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
