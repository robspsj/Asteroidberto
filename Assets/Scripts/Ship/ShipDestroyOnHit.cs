using UnityEngine;

namespace Asteroidsberto.Ship
{
    public class ShipDestroyOnHit : MonoBehaviour
    {
        [SerializeField] private ShipState _shipState;

        private void OnEnable()
        {
            _shipState.OnShipGotHit+= BulletStateOnOnDespawn;
        }

        private void OnDisable()
        {
            _shipState.OnShipGotHit -= BulletStateOnOnDespawn;
        }

        private void BulletStateOnOnDespawn()
        {
            Destroy(gameObject);
        }
    }
}