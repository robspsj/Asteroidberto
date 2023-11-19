using System.Collections;
using UnityEngine;

namespace Bullet
{
    public class DespawnAfterSeconds : MonoBehaviour
    {
        [SerializeField] private BulletState _bulletState;
        [SerializeField] private float _lifeTime = 1.5f;

        private void OnEnable()
        {
            StartCoroutine(DespawnAfterSecondsCoroutine());
        }

        private IEnumerator DespawnAfterSecondsCoroutine()
        {
            yield return new WaitForSeconds(_lifeTime);
            _bulletState.SetDespawn();
        }
    }
}