using UnityEngine;

namespace Components
{
    public abstract class CheckGround : MonoBehaviour
    {
        public abstract bool IsGrounded { get; }
        [SerializeField] private float distanceCheckRay = 0.1f;
        [SerializeField] private LayerMask groundMask;
        protected float GetDistanceCheckRay => distanceCheckRay;
        protected LayerMask GetGroundMask => groundMask;
        protected abstract void IsCheckGround();
    }
}