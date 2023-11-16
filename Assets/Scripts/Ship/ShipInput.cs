using UnityEngine;

namespace Asteroidsberto.Ship
{
    public class ShipInput : MonoBehaviour
    {
        [SerializeField] private ShipStateController _stateController;

        [SerializeField] private KeyCode _accelerateButton = KeyCode.Space;
        [SerializeField] private KeyCode _turnLeftButton = KeyCode.A;
        [SerializeField] private KeyCode _turnRightButton = KeyCode.D;
        [SerializeField] private KeyCode _shootButton = KeyCode.Return;

        private void Update()
        {
            _stateController.CurrentBoosterState = Input.GetKey(_accelerateButton)
                ? ShipStateController.BoosterState.On
                : ShipStateController.BoosterState.Off;

            var leftInput = Input.GetKey(_turnLeftButton);
            var rightInput = Input.GetKey(_turnRightButton);

            if (leftInput && !rightInput)
                _stateController.CurrentTurningState = ShipStateController.TurningState.Left;
            else if (!leftInput && rightInput)
                _stateController.CurrentTurningState = ShipStateController.TurningState.Right;
            else
                _stateController.CurrentTurningState = ShipStateController.TurningState.NotTurning;

            if (Input.GetKeyDown(_shootButton))
            {
                _stateController.ShootTrigger();
            }
        }
    }
}