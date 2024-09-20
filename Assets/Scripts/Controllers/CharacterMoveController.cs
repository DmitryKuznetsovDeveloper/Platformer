using Data;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public sealed class CharacterMoveController : ITickable
    {
        private readonly MoveUserInputData _moveUserInputData;
        private readonly SpriteRenderer _characterSprite;
        private readonly Transform _characterTransform;
        private readonly float _speed;

        public CharacterMoveController(
            MoveUserInputData moveUserInputData,
            SpriteRenderer characterSprite, 
            Transform transform, 
            float speed)
        {
            _moveUserInputData = moveUserInputData;
            _characterSprite = characterSprite;
            _characterTransform = transform;
            _speed = speed;
        }

        public void Tick()
        {
            var direction =
                new Vector3(_moveUserInputData.MoveInputData.x, 0f, 0f) *
                (_speed * Time.deltaTime);
            if (!direction.Equals(Vector3.zero))
            {
                _characterSprite.flipX = _moveUserInputData.MoveInputData.x < 0;
                _characterTransform.position += direction;
            }
        }
    }
}