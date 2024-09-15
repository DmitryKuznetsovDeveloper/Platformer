using SampleGame;
using UnityEngine;
using Zenject;

namespace Components
{
    public sealed class JumpComponent : CheckGround ,IGameTickable
    {
        public override bool IsGrounded => _isGrounded;
        [SerializeField] private float powerJump = 1000f;
        private Rigidbody2D _rg;
        private CapsuleCollider2D _capsuleCollider2D;
        private bool _isGrounded;

        [Inject]
        public void Construct(Rigidbody2D rb, CapsuleCollider2D capsuleCollider2D)
        {
            _rg = rb;
            _capsuleCollider2D = capsuleCollider2D;
        }

        public void Jump()
        {
            _rg.velocity = new Vector2(_rg.velocity.x, 0f);
            _rg.AddForce(Vector3.up * powerJump, ForceMode2D.Impulse);
        }
        

        protected override void IsCheckGround()
        {
            var bounds = _capsuleCollider2D.bounds;
            
            Debug.DrawRay(bounds.center,
                Vector3.down * (bounds.extents.y + GetDistanceCheckRay));

            _isGrounded = Physics2D.Raycast(_capsuleCollider2D.bounds.center, Vector3.down,
                bounds.extents.y + GetDistanceCheckRay, GetGroundMask);
        }

        public void Tick(float deltaTime) => 
            IsCheckGround();
    }
}