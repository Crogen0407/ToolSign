using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Crogen.PowerfulInput
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Crogen/InputReader", order = 0)]
    public class InputReader : ScriptableObject, Controls.IPlayerActions
    {
        #region Values

        public Vector3 InputVector { get; private set; }
        public Vector2 MouseDeltaPosition { get; private set; }

        #endregion
        
        #region Input Event

        public event Action DashEvent;
        public event Action AttackEvent;

        #endregion

        private Controls _controls;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if(context.performed)
                DashEvent?.Invoke();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            InputVector = context.ReadValue<Vector3>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if(context.performed)
                AttackEvent?.Invoke();
        }

        public void OnMouseDelta(InputAction.CallbackContext context)
        {
            MouseDeltaPosition = context.ReadValue<Vector2>();
            Debug.Log(MouseDeltaPosition);
        }
    }
}