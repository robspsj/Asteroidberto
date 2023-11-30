using UnityEngine;

namespace SimpleUnityObjectPool
{
    public class PoolElement : MonoBehaviour
    {
        private ObjectPool _pool;
        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }
        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void SetPool(ObjectPool pool)
        {
            _pool = pool;
        }
        
        public void ReturnToPool()
        {
            if (_pool)
            {
                _pool.Return(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}