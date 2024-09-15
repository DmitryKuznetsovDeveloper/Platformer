using Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public sealed class MenuScreenView : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        
        private ApplicationExiter _applicationExiter;
        private GameLauncher _gameLauncher;
        
        [Inject]
        public void Construct(
            ApplicationExiter applicationFinisher, 
            GameLauncher gameLauncher)
        {
            _gameLauncher = gameLauncher;
            _applicationExiter = applicationFinisher;
        }

        private void OnEnable()
        {
            startButton.onClick.AddListener(_gameLauncher.LaunchGame);
            exitButton.onClick.AddListener(_applicationExiter.ExitApp);
        }

        private void OnDisable()
        {
            startButton.onClick.RemoveListener(_gameLauncher.LaunchGame);
            exitButton.onClick.RemoveListener(_applicationExiter.ExitApp);
        }
    }
}