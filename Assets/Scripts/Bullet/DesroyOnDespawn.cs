using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Bullet
{
    public class DesroyOnDespawn : MonoBehaviour
    {
        [SerializeField] private BulletState _bulletState;
        private void OnEnable()
        {
            _bulletState.OnDespawn += BulletStateOnOnDespawn;
        }

        private void OnDisable()
        {
            _bulletState.OnDespawn -= BulletStateOnOnDespawn;
        }

        private void BulletStateOnOnDespawn()
        {
            Destroy(gameObject);
        }
    }
}