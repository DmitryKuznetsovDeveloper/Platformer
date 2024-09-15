using System;
using UnityEngine;

namespace Components
{
    public sealed class HealthComponent : MonoBehaviour
    {
        public event Action<int> OnRestoreHealth;
        public event Action<int> OnTakeDamage;
        public event Action OnDeath;
        public bool IsAlive() => health > 0;
        public bool IsHealthFull() => health == maxHitPoints;
        public int GetCurrentHitPoints() => health;

        [SerializeField, Min(0)] private int maxHitPoints = 10;
        [SerializeField, Min(0)] private int health = 3;
        
        public void TakeDamage(int damage)
        {
            health = Math.Max(0, health - damage);
            if (health <= 0)
                OnDeath?.Invoke();
            else
            {
                OnTakeDamage?.Invoke(damage);
                Debug.Log("OnTakeDamage");
            }
        }

        public void RestoreHitPoints(int healthPoints)
        {
            health = Mathf.Min(health + healthPoints, maxHitPoints);
            OnRestoreHealth?.Invoke(healthPoints);
        }
    }
}