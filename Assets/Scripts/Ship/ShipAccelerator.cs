using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroidsberto.Ship
{
    public class ShipAccelerator:MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [FormerlySerializedAs("_shipStateController")] [SerializeField] private ShipState _shipState;
        [SerializeField] private Transform _shipTransform;
        [SerializeField] private float _thrustForce = 1;

        private void FixedUpdate()
        {
            if (_shipState.CurrentBoosterState == ShipState.BoosterState.On)
            {
                Vector2 direction = _shipTransform.TransformDirection(Vector3.up);
                _rigidbody2D.AddForce(direction.normalized*_thrustForce, ForceMode2D.Force);
            }
        }
    }
}