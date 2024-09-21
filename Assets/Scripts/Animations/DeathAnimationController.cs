using Components;
using UnityEngine;
using Zenject;

namespace Animations
{
    public class DeathAnimationController : ITickable
    {
        private readonly Animator _animator;
        private readonly HealthComponent _healthComponent;
        private static readonly int IsDeath = Animator.StringToHash("Death");

        public DeathAnimationController(Animator animator, HealthComponent healthComponent)
        {
            _animator = animator;
            _healthComponent = healthComponent;
        }

        public void Tick() => 
            _animator.SetBool(IsDeath,!_healthComponent.IsAlive());
    }
}