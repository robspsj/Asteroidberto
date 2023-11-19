using System.Collections;
using UnityEngine;

namespace Asteroidsberto.Ship
{
    public class ShipBulletSpawner : MonoBehaviour
    {
        [SerializeField] private ShipStateController _shipStateController;
        [SerializeField] private float _bulletInterval = 0.2f;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Transform _bulletOrigin;
        [SerializeField] private GameObject _bulletPrefab;

        private float _lastBulletTime = float.NegativeInfinity;
        private bool _bulletQueued;

        private void OnEnable()
        {
            _shipStateController.OnShipShoot += OnBulletTrigger;
        }

        private void OnDisable()
        {
            _shipStateController.OnShipShoot -= OnBulletTrigger;
            _bulletQueued = false;
        }

        private void OnBulletTrigger()
        {
            var allowedBulletTime = _lastBulletTime + _bulletInterval;
            if (Time.time > allowedBulletTime && !_bulletQueued)
            {
                ShootBullet();
            }
            else
            {
                if (_bulletQueued)
                {
                    return;
                }

                _bulletQueued = true;
                StartCoroutine(ShootBulletAfterSeconds(allowedBulletTime - Time.time));
            }
        }

        private IEnumerator ShootBulletAfterSeconds(float delay)
        {
            yield return new WaitForSeconds(delay);
            ShootBullet();
            _bulletQueued = false;
        }

        private void ShootBullet()
        {
            _lastBulletTime = Time.time;
            Instantiate(_bulletPrefab,_bulletOrigin.position, _bulletOrigin.rotation, _worldTransform);
        }
    }
}