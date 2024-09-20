using Data;
using SampleGame;
using UnityEngine;

namespace Animations
{
    public sealed class MoveAnimatorController : IGameTickable
    {
        private readonly Animator _animator;
        private readonly MoveUserInputData _moveUserInputData;
        private static readonly int Move = Animator.StringToHash("Move");

        public MoveAnimatorController(Animator animator, MoveUserInputData moveUserInputData)
        {
            _animator = animator;
            _moveUserInputData = moveUserInputData;
        }

        public void Tick(float deltaTime) => 
            _animator.SetFloat(Move,Mathf.Abs(_moveUserInputData.MoveInputData.x));
    }
}