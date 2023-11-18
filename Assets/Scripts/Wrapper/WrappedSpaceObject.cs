using UnityEngine;

namespace Asteroidsberto.Wrapper
{
    public class WrappedSpaceObject:MonoBehaviour
    {
        public Transform Transform { private set; get; }
        private WrapperSpaceController _wrapperSpaceController;
        private void OnEnable()
        {
            _wrapperSpaceController = GetComponentInParent<WrapperSpaceController>();
            Transform = GetComponent<Transform>();
            _wrapperSpaceController?.RegisterObject(this);
        }

        private void OnDisable()
        {
            _wrapperSpaceController?.DeregisterObject(this);
        }
    }
}