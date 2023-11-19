using UnityEngine;

namespace Asteroidsberto.Bullet
{
    public class BulletStraightMovement : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _bulletSpeed = 10;

        private void OnEnable()
        {
            _rigidbody2D.velocity = _bulletSpeed * _transform.TransformDirection(Vector2.up);
        }
    }
}