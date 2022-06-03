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

        private MoveDirection _currentMoveDirection;

        private Vector3 _directionVector;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _directionVector = Vector3.forward;
            _currentMoveDirection = MoveDirection.Forward;
        }

        private void Update()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            _characterController.Move(_directionVector * Time.deltaTime * _speed);
        }

        public void TurnLeft(CallbackContext callback)
        {
            if (callback.phase == InputActionPhase.Started)
            {
                Vector3 newDirection = Vector3.zero;
                newDirection.x = -_directionVector.z;
                newDirection.z = _directionVector.x;

                _directionVector = newDirection;
            }
        }

        public void TurnRight(CallbackContext callback)
        {
            if (callback.phase == InputActionPhase.Started)
            {
                Vector3 newDirection = Vector3.zero;
                newDirection.x = _directionVector.z;
                newDirection.z = -_directionVector.x;

                _directionVector = newDirection;
            }
        }
    }
}
