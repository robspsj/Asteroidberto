using System.Collections;
using UnityEngine;

namespace Asteroidsberto.UI
{
    public class DestroyAfterSeconds : MonoBehaviour
    {
        [SerializeField] private float _durationTime = 4;
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_durationTime);
            Destroy(gameObject);
        }
    }
}