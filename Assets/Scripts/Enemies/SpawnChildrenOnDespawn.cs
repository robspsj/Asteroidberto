using UnityEngine;

namespace Asteroidsberto.Enemies
{
    public class SpawnChildrenOnDespawn : MonoBehaviour
    {
        [SerializeField] private EnemyState _bulletState;
        [SerializeField] private GameObject[] _spawnGroup;

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