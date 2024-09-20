using System;
using Data;
using SampleGame;
using UnityEngine.InputSystem;
using Zenject;

namespace Input
{
    public sealed class AttackUserInputSystem :  IInitializable,IGameTickable, IDisposable
    {
        private InputAction _attackNormalActionGamePad;
        private InputAction _attackComboActionGamePad;
        private bool _isNormalAttack;
        private bool _isComboAttack;

        private readonly AttackUserInputData _attackUserInputData;

        public AttackUserInputSystem(AttackUserInputData attackUserInputData) => 
            _attackUserInputData = attackUserInputData;

        void IInitializable.Initialize() 
        {
            _attackNormalActionGamePad = new InputAction("jumpGamepad", binding: "<Gamepad>/rightShoulder");
            _attackNormalActionGamePad.AddCompositeBinding("Dpad")
                .With("Left", "<Mouse>/leftButton");
            _attackNormalActionGamePad.performed += _ => _isNormalAttack = true;
            _attackNormalActionGamePad.canceled += _ => _isNormalAttack = false;
            _attackNormalActionGamePad.Enable();
            
            _attackComboActionGamePad = new InputAction("jumpGamepad", binding:  "<Gamepad>/rightTrigger");
            _attackComboActionGamePad.AddCompositeBinding("Dpad")
                .With("Right", "<Mouse>/rightButton");
  
            _attackComboActionGamePad.performed += _ => _isComboAttack = true;
            _attackComboActionGamePad.canceled += _ => _isComboAttack = false;
            _attackComboActionGamePad.Enable();
        }

        void IGameTickable.Tick(float deltaTime)
        {
            _attackUserInputData.IsNormalAttackInputData = _isNormalAttack;
            _attackUserInputData.IsComboAttackInputData = _isComboAttack;
        }

        void IDisposable.Dispose()
        {
            _attackNormalActionGamePad?.Dispose();
            _attackComboActionGamePad?.Dispose();
        }

    }
}