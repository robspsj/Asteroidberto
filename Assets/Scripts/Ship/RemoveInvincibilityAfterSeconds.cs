using System.Collections;
using UnityEngine;

namespace Asteroidsberto.Ship
{
    public class RemoveInvincibilityAfterSeconds : MonoBehaviour
    {
        [SerializeField] private ShipState _shipState;
        [SerializeField] private float _invincibilityTime = 1.5f;

        private void OnEnable()
        {
            if (_shipState.Invincible)
            {
                StartCoroutine(RemoveInvincibilityAfterSecondsCoroutine());
            }
        }

        private IEnumerator RemoveInvincibilityAfterSecondsCoroutine()
        {
            yield return new WaitForSeconds(_invincibilityTime);
            _shipState.Invincible = false;
        }
    }
}