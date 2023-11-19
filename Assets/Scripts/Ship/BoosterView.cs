using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroidsberto.Ship
{
    public class ShipBoosterView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _boosterSpriteRenderer;
        [FormerlySerializedAs("_shipStateController")] [SerializeField] private ShipState _shipState;

        private void OnEnable()
        {
            UpdateSpriteState(_shipState.CurrentBoosterState);
            _shipState.OnShipBoosterStateChange += OnBoosterStateChange;
        }

        private void OnDisable()
        {
            _shipState.OnShipBoosterStateChange -= OnBoosterStateChange;
        }

        private void OnBoosterStateChange(ShipState.BoosterState _, ShipState.BoosterState newState)
        {
            UpdateSpriteState(newState);
        }

        private void UpdateSpriteState(ShipState.BoosterState currentState)
        {
            _boosterSpriteRenderer.enabled = currentState == ShipState.BoosterState.On;
        }
    }
}