using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bullet
{
    public delegate void OnDespawn();

    public delegate void OnSpawn();

    public class BulletState : MonoBehaviour
    {
        public event OnDespawn OnDespawn;
        public event OnSpawn OnSpawn;
        public bool _spawned = false;

        private void OnEnable()
        {
            _spawned = true;
        }

        private void OnDisable()
        {
            _spawned = false;
        }

        public void SetDespawn()
        {
            if (!_spawned)
            {
                return;
            }
            _spawned = false;
            OnDespawn?.Invoke();
        }

        public void SetSpawn()
        {
            if (_spawned)
            {
                return;
            }
            _spawned = true;
            OnSpawn?.Invoke();
        }
    }
}