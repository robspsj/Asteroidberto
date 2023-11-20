using System.Text;
using GameLevel;
using TMPro;
using UnityEngine;

namespace Asteroidsberto.UI
{
    public class LivesIndicator : MonoBehaviour
    {
        [SerializeField] private GameLevelState _gameLevelState;
        [SerializeField] private TMP_Text _livesIndicator;
        [SerializeField] private string _lifeSymbol;
        private void OnEnable()
        {
            OnPlayerLivesChange(0, _gameLevelState.PlayerLives);
            _gameLevelState.OnPlayerLivesChange += OnPlayerLivesChange;
        }

        private void OnDisable()
        {
            _gameLevelState.OnPlayerLivesChange -= OnPlayerLivesChange;
        }

        void OnPlayerLivesChange(int _, int newLives)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < newLives; i++)
            {
                sb.Append(_lifeSymbol);
            }

            _livesIndicator.text = sb.ToString();
        }
    }
}