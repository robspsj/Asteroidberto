using UnityEngine;

namespace Asteroidsberto.Ship
{
    public class InvincibilityView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _invincibilitySpriteRenderer;
        [SerializeField] private ShipState _shipState;

        private void OnEnable()
        {
            UpdateSpriteState(_shipState.Invincible);
            _shipState.OnShipInvincibilityStateChange += OnBoosterStateChange;
        }

        private void OnDisable()
        {
            _shipState.OnShipInvincibilityStateChange -= OnBoosterStateChange;
        }

        private void OnBoosterStateChange(bool _, bool newState)
        {
            UpdateSpriteState(newState);
        }

        private void UpdateSpriteState(bool currentState)
        {
            _invincibilitySpriteRenderer.enabled = currentState;
        }
    }
}