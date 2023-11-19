using UnityEngine;

namespace Asteroidsberto.Bullet
{
    public class BulletCollisionDetector : MonoBehaviour
    {
        [SerializeField] private BulletState _bulletState;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Enemy"))
            {
                _bulletState.SetDespawn();
            }
        }
    }
}