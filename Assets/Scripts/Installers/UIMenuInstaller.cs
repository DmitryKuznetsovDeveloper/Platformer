using UI;
using Zenject;

namespace Installers
{
    public class UIMenuInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.BindInterfacesTo<MenuScreenView>().FromComponentsInHierarchy().AsSingle().NonLazy();
    }
}