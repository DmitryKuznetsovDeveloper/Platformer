using Animations;
using Cinemachine;
using Components;
using Controllers;
using Data;
using Input;
using Observers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public sealed class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private float speedMove;
        public override void InstallBindings()
        {
            //Data
            Container.Bind<MoveUserInputData>().AsCached().NonLazy();
            Container.Bind<JumpUserInputData>().AsCached().NonLazy();
            Container.Bind<AttackUserInputData>().AsCached().NonLazy();
            
            //Input
            Container.BindInterfacesTo<MoveUserInputSystem>().AsSingle().NonLazy();
            Container.BindInterfacesTo<JumpUserInputSystem>().AsSingle().NonLazy();
            Container.BindInterfacesTo<AttackUserInputSystem>().AsSingle().NonLazy();
            
            //Controller
            Container.BindInterfacesAndSelfTo<CharacterMoveController>().AsSingle().WithArguments(transform,speedMove).NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterJumpController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterSideCameraController>().AsSingle().NonLazy();
            
            //Components
            Container.Bind<Rigidbody2D>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<CapsuleCollider2D>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<SpriteRenderer>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<HealthComponent>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<DeathObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JumpComponent>().FromComponentInHierarchy().AsSingle().NonLazy();
            
            //Animations
            Container.Bind<Animator>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MoveAnimatorController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JumpAnimationController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AttackAnimationController>().AsSingle().NonLazy();
        }
    }
}