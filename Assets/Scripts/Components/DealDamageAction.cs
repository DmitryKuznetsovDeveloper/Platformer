using UnityEngine;

namespace Components
{
    public sealed class DealDamageAction : MonoBehaviour
    {
        [SerializeField] private int damage;

        public void OnTriggerEnter2D(Collider2D other) =>
            DealDamage(other, damage);

        private void OnCollisionEnter2D(Collision2D other) => 
            DealDamage(other, damage);

        private void DealDamage(Collider2D collider, int damage)
        {
            if (collider.TryGetComponent(out HealthComponent healthComponent)) 
                healthComponent.TakeDamage(damage);
        }
        
        private void DealDamage(Collision2D collision, int damage)
        {
            if (collision.gameObject.TryGetComponent(out HealthComponent healthComponent)) 
                healthComponent.TakeDamage(damage);
        }
    }
}