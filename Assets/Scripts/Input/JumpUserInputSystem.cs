using System;
using Data;
using SampleGame;
using UnityEngine.InputSystem;
using Zenject;

namespace Input
{
    public class JumpUserInputSystem : IInitializable,IGameTickable, IDisposable
    {
        private InputAction _jumpActionGamePad;
        private InputAction _jumpActionKeyboard;
        private bool _jumpInput;

        private readonly JumpUserInputData _inputData;
        public JumpUserInputSystem(JumpUserInputData inputData) => _inputData = inputData;

        void IInitializable.Initialize() 
        {
            _jumpActionGamePad = new InputAction("jumpGamepad", binding: "<Gamepad>/Cross");
            _jumpActionKeyboard = new InputAction("jumpKeyboard", binding: "<Keyboard>/Space");
            
            _jumpActionGamePad.performed += _ => _jumpInput = true;
            _jumpActionGamePad.canceled += _ => _jumpInput = false;
            _jumpActionGamePad.Enable();
            _jumpActionKeyboard.performed += _ => _jumpInput = true;
            _jumpActionKeyboard.canceled += _ => _jumpInput = false;
            _jumpActionKeyboard.Enable();
        }

        void IGameTickable.Tick(float deltaTime) =>
            _inputData.JumpInputData = _jumpInput;

        void IDisposable.Dispose()
        {
            _jumpActionGamePad?.Dispose();
            _jumpActionKeyboard?.Dispose();
        }


    }
}