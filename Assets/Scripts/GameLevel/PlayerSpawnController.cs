using System;
using System.Collections;
using Asteroidsberto.Ship;
using UnityEngine;

namespace GameLevel
{
    public class PlayerSpawnController : MonoBehaviour
    {
        [SerializeField] private GameLevelState _gameLevelState;
        [SerializeField] private ShipState _shipState;
        [SerializeField] private GameObject _shipPrefab;
        [SerializeField] private Transform _worldTransform;

        private void OnEnable()
        {
            var shipState = FindObjectOfType<ShipState>();
            
            if (shipState != null)
            {
                _shipState = shipState;
                RegisterShip(_shipState);
            }
        }

        private void RegisterShip(ShipState shipState)
        {
            shipState.OnShipGotHit += ShipStateOnOnShipGotHit;
        }

        private void DeregisterShip(ShipState shipState)
        {
            shipState.OnShipGotHit -= ShipStateOnOnShipGotHit;
        }
        private void ShipStateOnOnShipGotHit()
        {
            DeregisterShip(_shipState);

            if (_gameLevelState.PlayerLives <= 0) return;
            
            StartCoroutine(SpawnShip());
            _gameLevelState.PlayerLives -= 1;
        }

        private IEnumerator SpawnShip()
        {
            yield return new WaitForSeconds(1);
            GameObject newShip = Instantiate(_shipPrefab, _worldTransform);
            _shipState = newShip.GetComponent<ShipState>();
            RegisterShip(_shipState);
        }
    }
}