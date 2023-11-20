using System;
using UnityEngine;

namespace GameLevel
{
    public delegate void PlayerLivesChange(int previousLives, int newLives);
    public class GameLevelState : MonoBehaviour
    {
        public event PlayerLivesChange PlayerLivesChange;
        
        [SerializeField] private int _defaultPLayerLives = 3;
        private int _playerLives ;
        
        public int PlayerLives
        {
            set
            {
                if (value == _playerLives) return;
                
                var oldLives = _playerLives;
                _playerLives = value;
                PlayerLivesChange?.Invoke(oldLives, value);
            }
            get => _playerLives;
        }

        private void Awake()
        {
            _playerLives = _defaultPLayerLives;
        }
    }
}