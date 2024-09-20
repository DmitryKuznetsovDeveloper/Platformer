using Zenject;

namespace Installers
{
    public sealed class UIInstaller : MonoInstaller
    { 
       // [SerializeField] private HudScreen hudScreen;
       // [SerializeField] private PauseScreen pauseScreen;
       // [SerializeField] private GameOverScreen gameOverScreen;
        
        public override void InstallBindings()
        {
        //   Container.BindInterfacesTo<HudScreen>().FromInstance(this.hudScreen);
        //    Container.BindInterfacesTo<PauseScreen>().FromInstance(this.pauseScreen);
          //  Container.BindInterfacesTo<GameOverScreen>().FromInstance(this.gameOverScreen);
        }
    }
}