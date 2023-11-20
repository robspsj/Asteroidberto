using GameLevel;
using UnityEngine;

namespace Asteroidsberto.UI
{
    public class EnableWhenNoLives : MonoBehaviour
    {
        [SerializeField] private GameLevelState _gameLevelState;
        [SerializeField] private GameObject _gameObject;
        private void OnEnable()
        {
            _gameLevelState.OnPlayerLivesChange += OnPlayerLivesChange;
        }

        private void OnDisable()
        {
            _gameLevelState.OnPlayerLivesChange -= OnPlayerLivesChange;
        }

        void OnPlayerLivesChange(int _, int newLives)
        {
            if (newLives == 0)
            {
                _gameObject.SetActive(true);
            }
        }
    }
}