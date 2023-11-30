using UnityEngine;

namespace GameLevel
{
    public delegate void PlayerLivesChange(int previousValue, int newValue);
    public delegate void EnemyCountChange(int previousValue, int newValue);
    public class GameLevelState : MonoBehaviour
    {
        public event PlayerLivesChange OnPlayerLivesChange;
        public event EnemyCountChange OnEnemyCountChange;
        
        [SerializeField] private int _defaultPLayerLives = 3;
        private int _playerLives ;
        private int _enemyCount ;
        public int StartedWaves { get; set; }
        
        public int PlayerLives
        {
            set
            {
                if (value == _playerLives) return;
                
                int oldLives = _playerLives;
                _playerLives = value;
                OnPlayerLivesChange?.Invoke(oldLives, value);
            }
            get => _playerLives;
        }
        public int EnemyCount
        {
            set
            {
                if (value == _enemyCount) return;
                int oldCount = _enemyCount;
                _enemyCount = value;
                OnEnemyCountChange?.Invoke(oldCount, value);
            }
            get => _enemyCount;
        }
        
        private void Awake()
        {
            PlayerLives = _defaultPLayerLives;
        }
    }
}