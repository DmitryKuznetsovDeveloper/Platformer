using Components;
using Data;
using SampleGame;
using UnityEngine;

namespace Animations
{
    public sealed class JumpAnimationController : IGameTickable
    {
        private readonly Animator _animator;
        private readonly JumpUserInputData _jumpUserInputData;
        private readonly JumpComponent _jumpComponent;
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");

        public JumpAnimationController(Animator animator, JumpUserInputData jumpUserInputData, JumpComponent jumpComponent)
        {
            _animator = animator;
            _jumpUserInputData = jumpUserInputData;
            _jumpComponent = jumpComponent;
        }

        public void Tick(float deltaTime)
        {
            _animator.SetBool(IsGrounded, _jumpComponent.IsGrounded);
            if( _jumpUserInputData.IsJumpInputData && _jumpComponent.IsGrounded) 
                _animator.SetTrigger(Jump);
        }
    }
}