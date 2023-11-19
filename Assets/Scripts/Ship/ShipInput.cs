using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroidsberto.Ship
{
    public class ShipInput : MonoBehaviour
    {
        [FormerlySerializedAs("_stateController")] [SerializeField] private ShipState _state;

        [SerializeField] private KeyCode _accelerateButton = KeyCode.Space;
        [SerializeField] private KeyCode _turnLeftButton = KeyCode.A;
        [SerializeField] private KeyCode _turnRightButton = KeyCode.D;
        [SerializeField] private KeyCode _shootButton = KeyCode.Return;

        private void Update()
        {
            _state.CurrentBoosterState = Input.GetKey(_accelerateButton)
                ? ShipState.BoosterState.On
                : ShipState.BoosterState.Off;

            var leftInput = Input.GetKey(_turnLeftButton);
            var rightInput = Input.GetKey(_turnRightButton);

            if (leftInput && !rightInput)
                _state.CurrentTurningState = ShipState.TurningState.Left;
            else if (!leftInput && rightInput)
                _state.CurrentTurningState = ShipState.TurningState.Right;
            else
                _state.CurrentTurningState = ShipState.TurningState.NotTurning;

            if (Input.GetKeyDown(_shootButton))
            {
                _state.ShootTrigger();
            }
        }
    }
}