using UnityEngine;
using UnityEngine.Serialization;


namespace Asteroidsberto.Enemies
{
    public class EnemyDestroyOnDespawn : MonoBehaviour
    {
        [SerializeField] private EnemyState _enemyState;

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
            Destroy(gameObject);
        }
    }
}