using Components;
using Plugins.GameCycle;
using SampleGame;

namespace Observers
{
    public sealed class DeathObserver : IGameStartListener, IGameFinishListener
    {
        private readonly HealthComponent _healthComponent;
        private readonly GameManager _gameManager;

        public DeathObserver(
            HealthComponent healthComponent,
            GameManager gameManager)
        {
            _healthComponent = healthComponent;
            _gameManager = gameManager;
        }
         void IGameStartListener.OnStartGame() => 
             _healthComponent.OnDeath += SetOnDeath;

         void IGameFinishListener.OnFinishGame() => 
             _healthComponent.OnDeath -= SetOnDeath;

         private void SetOnDeath() => _gameManager.FinishGame();

    }
}