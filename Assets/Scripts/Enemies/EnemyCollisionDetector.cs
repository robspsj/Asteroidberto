using UnityEngine;

namespace Asteroidsberto.Enemies
{
    public class EnemyCollisionDetector : MonoBehaviour
    {
        [SerializeField] private EnemyState _enemyState;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Bullet"))
            {
                _enemyState.SetDespawn();
            }
        }
    }
}