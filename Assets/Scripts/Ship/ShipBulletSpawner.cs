using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Asteroidsberto.Ship
{
    public class ShipBulletSpawner : MonoBehaviour
    {
        [SerializeField] private ShipStateController _shipStateController;
        
        [SerializeField] private float _bulletInterval = 1;
        [SerializeField] private float _lastBulletTime = float.NegativeInfinity;
        [SerializeField] private bool _bulletQueued;
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
            Debug.Log("Bullet");
        }
    }
}