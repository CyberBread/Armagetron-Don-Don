using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Armagetron.Movement
{
    public class LightcycleControl : MonoBehaviour
    {
        [SerializeField] private float _speed = 30;
        [SerializeField] private float _speedIncrement;

        private CharacterController _characterController;

        private Vector3 _moveDirection;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _moveDirection = Vector3.forward;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _characterController.Move(_moveDirection * Time.deltaTime * _speed);
        }

        public void TurnLeft(CallbackContext callback)
        {
            if (callback.phase == InputActionPhase.Started)
            {
                ChangeMoveDirectionToLeft();
                transform.Rotate(new Vector3(0,-90,0));
            }
        }

        public void TurnRight(CallbackContext callback)
        {
            if (callback.phase == InputActionPhase.Started)
            {
                ChangeMoveDirectionToRight();
                transform.Rotate(new Vector3(0,90,0));
            }
        }

        private void ChangeMoveDirectionToLeft()
        {
            Vector3 newDirection = Vector3.zero;
            newDirection.x = -_moveDirection.z;
            newDirection.z = _moveDirection.x;

            _moveDirection = newDirection;
        }

        private void ChangeMoveDirectionToRight()
        {
            Vector3 newDirection = Vector3.zero;
            newDirection.x = _moveDirection.z;
            newDirection.z = -_moveDirection.x;

            _moveDirection = newDirection;
        }
    }
}
