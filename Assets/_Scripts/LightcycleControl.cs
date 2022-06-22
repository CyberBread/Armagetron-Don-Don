using System.Collections;
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
                ChangeMoveDirectionToLeft();
                StartCoroutine(SmoothRotate(TurnDirection.Left));
            }
        }

        public void TurnRight(CallbackContext callback)
        {
            if (callback.phase == InputActionPhase.Started)
            {
                ChangeMoveDirectionToRight();
                StartCoroutine(SmoothRotate(TurnDirection.Right));
            }
        }

        private IEnumerator SmoothRotate(TurnDirection direction, float turnTime = 0.1f)
        {
            Quaternion target = Quaternion.identity;
            switch (direction)
            {
                case TurnDirection.Left:
                    target = transform.rotation * Quaternion.Euler(0, -90f, 0);
                    break;
                case TurnDirection.Right:
                    target = transform.rotation * Quaternion.Euler(0, 90f, 0);
                    break;
            }

            float delta = 0.1f;
            while (delta <= 1)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, target, delta);
                delta += 0.1F;
                yield return new WaitForSeconds(0.2f);
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
