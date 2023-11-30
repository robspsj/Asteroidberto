using SimpleUnityObjectPool;
using UnityEngine;

namespace GameLevel
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPool _enemyPool;
        [SerializeField] private Transform _world;
        [SerializeField] private GameLevelState _gameLevelState;

        private void OnEnable()
        {
            _gameLevelState.OnEnemyCountChange += OnEnemyCountChange;

            if (_gameLevelState.EnemyCount == 0)
            {
                SpawnNextWave();
            }
        }
        
        private void OnDisable()
        {
            _gameLevelState.OnEnemyCountChange -= OnEnemyCountChange;
        }

        private void OnEnemyCountChange(int _, int newValue)
        {
            if (newValue == 0)
            {
                SpawnNextWave();
            }
        }

        private void SpawnNextWave()
        {
            const float screenHeightInWorldSpace = 5f;
            const float screenWidthInWorldSpace = 5f * 16f / 9f;
            
            _gameLevelState.StartedWaves += 1;
            int wavesCount = 5 + _gameLevelState.StartedWaves;
            
            for (var i = 0; i < wavesCount; i++)
            {
                float random = Random.value * (screenHeightInWorldSpace + screenWidthInWorldSpace);

                Vector2 spawnOrigin = new Vector2(-screenHeightInWorldSpace*0.5f, - screenWidthInWorldSpace*0.5f);
                Vector2 spawnPosition = random < screenWidthInWorldSpace
                    ? spawnOrigin + new Vector2(random, 0)
                    : spawnOrigin + new Vector2(0, random - screenWidthInWorldSpace);

                Transform poolElement = _enemyPool.Extract().transform;
                poolElement.parent = _world;
                poolElement.position = spawnPosition;
            }
        }
    }
}