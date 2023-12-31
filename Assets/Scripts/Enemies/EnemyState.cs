﻿using UnityEngine;

namespace Asteroidsberto.Enemies
{
    public delegate void OnDespawn();

    public delegate void OnSpawn();

    public class EnemyState : MonoBehaviour
    {
        public event OnDespawn OnDespawn;
        public event OnSpawn OnSpawn;
        private bool _spawned = false;
        public bool Spawned => _spawned;

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