using UnityEngine;

namespace Asteroidsberto.Ship
{
    public class ShipCollisionDetector : MonoBehaviour
    {
        [SerializeField] private ShipState _enemyState;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Enemy") || other.collider.CompareTag("EnemyBullet"))
            {
                _enemyState.GetHit();
            }
        }
    }
}