using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityComponents.Common
{
    public class InputControl : MonoBehaviour
    {
        private Controllers _controllers;

        private float _rotationDirection = 0f;
        private float _move = 0f;
        private bool _fire = false;

        private void Awake()
        {
            _controllers = new Controllers();
        }

        private void OnEnable()
        {
            _controllers.Enable();
        }

        private void OnDisable()
        {
            _controllers.Disable();
        }

        private void Start()
        {
            _controllers.GameControllers.ForwardMove.started += ctx => VerticalKeyDownStarted(ctx);
            _controllers.GameControllers.ForwardMove.canceled += ctx => VerticalKeyDownEnded();

            _controllers.GameControllers.RotationMove.started += ctx => HorizontalKeyDownStarted(ctx);
            _controllers.GameControllers.RotationMove.canceled += ctx => HorizontalKeyDownEnded();

            _controllers.GameControllers.FireButton.performed += ctx => FireKeyDownStarted();
        }

        private void HorizontalKeyDownStarted(InputAction.CallbackContext context)
        {
            _rotationDirection = context.ReadValue<float>();
        }

        private void HorizontalKeyDownEnded()
        {
            _rotationDirection = 0f;
        }

        private void VerticalKeyDownStarted(InputAction.CallbackContext context)
        {
            _move = context.ReadValue<float>();
        }

        private void VerticalKeyDownEnded()
        {
            _move = 0f;
        }

        private void FireKeyDownStarted()
        {
            _fire = true;
        }


        public float GetHorizontalAxis()
        {
            return _rotationDirection;
        }

        public float GetVerticalAxis()
        {
            return _move;
        }

        public bool GetFire()
        {
            bool temp = _fire;
            _fire = false;
            return temp;
        }
    }
}
