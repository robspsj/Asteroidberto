using UnityEngine;

namespace Asteroidsberto.Ship
{
    public class ShipTurner : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private ShipStateController _shipStateController;
        [SerializeField] private float _turningAngularSpeed = 1;

        private void FixedUpdate()
        {
            float turningDirection = _shipStateController.CurrentTurningState switch
            {
                ShipStateController.TurningState.Left => 1,
                ShipStateController.TurningState.Right => -1,
                _ => 0
            };

            _rigidbody2D.rotation += turningDirection * _turningAngularSpeed * Time.fixedDeltaTime;
        }
    }
}