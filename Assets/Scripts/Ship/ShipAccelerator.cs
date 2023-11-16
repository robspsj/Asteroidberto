using UnityEngine;

namespace Asteroidsberto.Ship
{
    public class ShipAccelerator:MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private ShipStateController _shipStateController;
        [SerializeField] private Transform _shipTransform;
        [SerializeField] private float _thrustForce = 1;

        private void FixedUpdate()
        {
            if (_shipStateController.CurrentBoosterState == ShipStateController.BoosterState.On)
            {
                Vector2 direction = _shipTransform.TransformDirection(Vector3.up);
                _rigidbody2D.AddForce(direction.normalized*_thrustForce, ForceMode2D.Force);
            }
        }
    }
}