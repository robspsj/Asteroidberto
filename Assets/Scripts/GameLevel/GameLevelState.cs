using UnityEngine;

namespace GameLevel
{
    public delegate void PlayerLivesChange(int previousLives, int newLives);
    public class GameLevelState : MonoBehaviour
    {
        public event PlayerLivesChange OnPlayerLivesChange;
        
        [SerializeField] private int _defaultPLayerLives = 3;
        private int _playerLives ;
        
        public int PlayerLives
        {
            set
            {
                if (value == _playerLives) return;
                
                var oldLives = _playerLives;
                _playerLives = value;
                OnPlayerLivesChange?.Invoke(oldLives, value);
            }
            get => _playerLives;
        }

        private void Awake()
        {
            PlayerLives = _defaultPLayerLives;
        }
    }
}