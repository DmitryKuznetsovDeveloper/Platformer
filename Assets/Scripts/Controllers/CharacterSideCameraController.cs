using Cinemachine;
using Data;
using DG.Tweening;
using SampleGame;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public sealed class CharacterSideCameraController : IInitializable, IGameTickable
    {
        private readonly MoveUserInputData _moveUserInputData;
        private readonly CinemachineVirtualCamera _characterCamera;
        private CinemachineFramingTransposer _cameraTransposer;
        private readonly float _normalScreenX = 0.5f;
        private readonly float _time = 1f;

        public CharacterSideCameraController(MoveUserInputData moveUserInputData,
            CinemachineVirtualCamera characterCamera)
        {
            _moveUserInputData = moveUserInputData;
            _characterCamera = characterCamera;
        }

        public void Initialize()
        {
            _cameraTransposer = _characterCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            _cameraTransposer.m_ScreenX = _normalScreenX;
        }

        public void Tick(float deltaTime)
        {
            if (!_moveUserInputData.MoveInputData.Equals(Vector2.zero))
            {
                var screenX = _moveUserInputData.MoveInputData.x > 0 ? 0.2f : 0.8f;
                DOTween.To(() =>_cameraTransposer.m_ScreenX, x => _cameraTransposer.m_ScreenX = x, screenX, _time)
                    .SetEase(Ease.OutSine);
            }
        }
    }
}