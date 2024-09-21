using Game;
using SampleGame;
using UI.View;
using Zenject;

namespace UI
{
    public sealed class GameOverMediator : IInitializable, IGameFinishListener
    {
        private readonly GameLauncher _gameLauncher;
        private readonly GameOverView _gameOverScreenView;
        private readonly float _timeRestart = 5;
        
        public GameOverMediator(GameLauncher gameLauncher, GameOverView gameOverScreenView)
        {
            _gameLauncher = gameLauncher;
            _gameOverScreenView = gameOverScreenView;
        }
        
        void IInitializable.Initialize() => 
            _gameOverScreenView.gameObject.SetActive(false);

        void IGameFinishListener.OnFinishGame()
        {
            _gameOverScreenView.gameObject.SetActive(true);
            _gameOverScreenView.PlayDeathScreen();
            _gameLauncher.DelayResetCurrentScene(_timeRestart);
        }
        
        
    }
}