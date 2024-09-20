using Controllers;
using Game;
using Plugins.GameCycle;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/GameInstaller", order = 0)]
    public class GameCoreInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameLauncher>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ApplicationExiter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameTimer>().AsSingle();
            
        }
    }
}