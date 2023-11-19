using UnityEngine;

namespace Asteroidsberto.Bullet
{
    public class BulletDestroyOnDespawn : MonoBehaviour
    {
        [SerializeField] private BulletState _bulletState;
        private void OnEnable()
        {
            _bulletState.OnDespawn += BulletStateOnOnDespawn;
        }

        private void OnDisable()
        {
            _bulletState.OnDespawn -= BulletStateOnOnDespawn;
        }

        private void BulletStateOnOnDespawn()
        {
            Destroy(gameObject);
        }
    }
}