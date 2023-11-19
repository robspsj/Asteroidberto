using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroidsberto.Ship
{
    public class ShipTurner : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [FormerlySerializedAs("_shipStateController")] [SerializeField] private ShipState _shipState;
        [SerializeField] private float _turningAngularSpeed = 1;

        private void FixedUpdate()
        {
            float turningDirection = _shipState.CurrentTurningState switch
            {
                ShipState.TurningState.Left => 1,
                ShipState.TurningState.Right => -1,
                _ => 0
            };

            _rigidbody2D.rotation += turningDirection * _turningAngularSpeed * Time.fixedDeltaTime;
        }
    }
}