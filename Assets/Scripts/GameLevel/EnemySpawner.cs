using Extension;
using UnityEngine;

namespace GameLevel
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Transform _world;
        [SerializeField] private Camera _camera;
        [SerializeField] private GameLevelState _gameLevelState;

        private void OnEnable()
        {
            _gameLevelState.OnEnemyCountChange += OnEnemyCountChange;
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
            Bounds bounds = _camera.GetCameraBoundingBox();
            _gameLevelState.CompletedWaves += 1;
            var wavesCount = 5 + _gameLevelState.CompletedWaves;
            for (var i = 0; i < wavesCount; i++)
            {
                float random = Random.value * (bounds.size.x + bounds.size.y);

                Vector2 spawnOrigin = bounds.center - bounds.size * 0.5f;
                Vector2 spawnPosition = random < bounds.size.x
                    ? spawnOrigin + new Vector2(random, 0)
                    : spawnOrigin + new Vector2(0, random - bounds.size.x);
                Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity, _world);
            }
        }
    }
}