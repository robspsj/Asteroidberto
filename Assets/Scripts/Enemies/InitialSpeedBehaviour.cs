using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroidsberto.Enemies
{
    public class InitialSpeedBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeedLowerRange = 5;
        [SerializeField] private float _rotationSpeedUpperRange = 30;

        private void OnEnable()
        {
            var angle = Random.value * 2 * Mathf.PI;
            _rigidbody2D.velocity = new Vector2(Mathf.Sin(angle) * _speed, Mathf.Cos(angle) * _speed);
            var angularVelocity = _rotationSpeedLowerRange +
                                             Random.value * (_rotationSpeedUpperRange - _rotationSpeedLowerRange);
            var rotationDirection = Random.value > 0.5 ? 1 : -1;
            _rigidbody2D.angularVelocity = angularVelocity * rotationDirection;
        }
    }
}