using UnityEngine;


namespace Asteroidsberto.Enemies
{
    public class EnemyDestroyOnDespawn : MonoBehaviour
    {
        [SerializeField] private EnemyState _bulletState;

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