using UI;
using UI.View;
using Zenject;

namespace Installers
{
    public sealed class UIInstaller : MonoInstaller
    { 
        public override void InstallBindings()
        {
            //Character
            Container.Bind<CharacterInstaller>().FromComponentInHierarchy().AsSingle().NonLazy();
            
            //View
            Container.Bind<GameOverView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<HealthBarView>().FromComponentInHierarchy().AsSingle().NonLazy();
            
            //Mediator
            Container.BindInterfacesTo<GameOverMediator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<HUDMediator>().AsSingle().NonLazy();
        }
    }
}