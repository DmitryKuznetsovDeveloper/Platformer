using Plugins.GameCycle;
using Zenject;

namespace Controllers
{
    public sealed class GameController : IInitializable, ITickable
    {
        
        private readonly GameManager _gameManager;

        public GameController(
            GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        void IInitializable.Initialize() => 
            _gameManager.StartGame();

        void ITickable.Tick()
        { 
            //TODO: сделать паузу игры
           // if (_characterInputHandler.ESCTrigger) 
              //  _gameManager.PauseGame();
        }
    }
}