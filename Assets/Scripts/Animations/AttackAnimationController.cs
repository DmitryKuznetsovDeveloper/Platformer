using Data;
using SampleGame;
using UnityEngine;

namespace Animations
{
    public sealed class AttackAnimationController : IGameTickable
    {
        private readonly Animator _animator;
        private readonly AttackUserInputData _attackUserInputData;
        private static readonly int IsNormalAttack = Animator.StringToHash("IsNormalAttack");
        private static readonly int IsComboAttack = Animator.StringToHash("IsComboAttack");

        public AttackAnimationController(Animator animator, AttackUserInputData attackUserInputData)
        {
            _animator = animator;
            _attackUserInputData = attackUserInputData;
        }


        public void Tick(float deltaTime)
        {
            _animator.SetBool(IsNormalAttack,_attackUserInputData.IsNormalAttackInputData);
            _animator.SetBool(IsComboAttack,_attackUserInputData.IsComboAttackInputData);
        }
    }
}