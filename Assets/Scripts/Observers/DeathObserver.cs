using Components;
using SampleGame;
using Zenject;

namespace Observers
{
    public sealed class DeathObserver : IInitializable, IGameFinishListener
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
         void IInitializable.Initialize() => 
             _healthComponent.OnDeath += _gameManager.FinishGame;

         void IGameFinishListener.OnFinishGame() => 
             _healthComponent.OnDeath -= _gameManager.FinishGame;
    }
}