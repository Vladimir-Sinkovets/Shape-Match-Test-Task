using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Game.Scripts.Core.Inputs
{
    public class Input : IInput, IDisposable
    {
        public event Action<Vector2> OnTouched;

        private TouchActions _inputActions;

        public Input()
        {
            _inputActions = new TouchActions();

            _inputActions.Enable();

            _inputActions.Game.TouchPress.started += OnTouchStartedHandler;
        }

        private void OnTouchStartedHandler(InputAction.CallbackContext context)
        {
            OnTouched?.Invoke(_inputActions.Game.TouchPosition.ReadValue<Vector2>());
        }

        public void Dispose()
        {
            _inputActions.Game.Touch.started -= OnTouchStartedHandler;
        }
    }
}
