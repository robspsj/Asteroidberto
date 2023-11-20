using UnityEngine;

namespace Asteroidsberto.GameLevel
{
    public class EnemyGroupElement : MonoBehaviour
    {
        private EnemyGroupCounter _enemyGroupCounter;

        private void OnEnable()
        {
            _enemyGroupCounter = GetComponentInParent<EnemyGroupCounter>();
            _enemyGroupCounter.RegisterObject(this);
        }
        
        private void OnDisable()
        {
            _enemyGroupCounter.DeregisterObject(this);
        }
    }
}