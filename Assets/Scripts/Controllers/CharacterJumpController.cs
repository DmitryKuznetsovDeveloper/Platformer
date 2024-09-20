using Components;
using Data;
using SampleGame;
using Zenject;

namespace Controllers
{
    public sealed class CharacterJumpController :IGameTickable
    {
        private JumpUserInputData _jumpUserInputData;
        private JumpComponent _jumpComponent;

        [Inject]
        public void Construct(JumpUserInputData jumpUserInputData, 
            JumpComponent jumpComponent)
        {
            _jumpUserInputData = jumpUserInputData;
            _jumpComponent = jumpComponent;
        }

        public void Tick(float deltaTime)
        {
            if (_jumpComponent.IsGrounded && _jumpUserInputData.IsJumpInputData) 
                _jumpComponent.Jump();
        }
    }
}