using UnityEngine;

namespace Asteroidsberto.Ship
{
    public class ShipBoosterView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _boosterSpriteRenderer;
        [SerializeField] private ShipStateController _shipStateController;

        private void OnEnable()
        {
            UpdateSpriteState(_shipStateController.CurrentBoosterState);
            _shipStateController.OnShipBoosterStateChange += OnBoosterStateChange;
        }

        private void OnDisable()
        {
            _shipStateController.OnShipBoosterStateChange -= OnBoosterStateChange;
        }

        private void OnBoosterStateChange(ShipStateController.BoosterState _, ShipStateController.BoosterState newState)
        {
            UpdateSpriteState(newState);
        }

        private void UpdateSpriteState(ShipStateController.BoosterState currentState)
        {
            _boosterSpriteRenderer.enabled = currentState == ShipStateController.BoosterState.On;
        }
    }
}