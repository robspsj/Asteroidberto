using UnityEngine;

namespace Asteroidsberto.Enemies
{
    public class SpawnChildrenOnDespawn : MonoBehaviour
    {
        [SerializeField] private EnemyState _enemyState;
        [SerializeField] private GameObject[] _spawnGroup;
        [SerializeField] private Transform _transform;

        private void OnEnable()
        {
            _enemyState.OnDespawn += EnemyStateOnOnDespawn;
        }

        private void OnDisable()
        {
            _enemyState.OnDespawn -= EnemyStateOnOnDespawn;
        }

        private void EnemyStateOnOnDespawn()
        {
            foreach (GameObject spawnedObject in _spawnGroup)
            {
                Instantiate(spawnedObject, _transform.position, Quaternion.identity, _transform.parent);
            }
        }
    }
}