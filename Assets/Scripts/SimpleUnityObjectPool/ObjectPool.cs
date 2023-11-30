using System.Collections.Generic;
using UnityEngine;

namespace SimpleUnityObjectPool
{
    public class ObjectPool : MonoBehaviour
    {
        public PoolElement BasePrefab;
        private readonly List<PoolElement> _pooledElements = new();
        public void Return(PoolElement poolElement)
        {
            poolElement.Deactivate();
            poolElement.transform.SetParent(transform);
            _pooledElements.Add(poolElement);
        }
        
        public PoolElement Extract()
        {
            PoolElement objectToExtract;
            if (_pooledElements.Count == 0)
            {
                objectToExtract = Instantiate(BasePrefab, transform, false);
                objectToExtract.SetPool(this);
            }
            else
            {
                objectToExtract = _pooledElements[_pooledElements.Count-1];
                _pooledElements.RemoveAt(_pooledElements.Count-1);
            }
            objectToExtract.Activate();
            return objectToExtract;
        }
    }
}