using System.Collections.Generic;
using Extension;
using UnityEngine;

namespace Asteroidsberto.Wrapper
{
    public class WrapperSpaceController : MonoBehaviour
    {
        private readonly List<WrappedSpaceObject> _wrappedSpaceObjects = new();
        private Camera _camera;

        private void OnEnable()
        {
            _camera = Camera.main;
        }

        private void FixedUpdate()
        {
            Bounds cameraBounds = _camera.GetCameraBoundingBox();

            foreach (WrappedSpaceObject spaceObject in _wrappedSpaceObjects)
            {
                if (spaceObject.Transform.position.x < cameraBounds.min.x)
                    spaceObject.Transform.position += Vector3.right * cameraBounds.size.x;
                if (spaceObject.Transform.position.x > cameraBounds.max.x)
                    spaceObject.Transform.position += Vector3.left * cameraBounds.size.x;
                if (spaceObject.Transform.position.y < cameraBounds.min.y)
                    spaceObject.Transform.position += Vector3.up * cameraBounds.size.y;
                if (spaceObject.Transform.position.y > cameraBounds.max.y)
                    spaceObject.Transform.position += Vector3.down * cameraBounds.size.y;
            }
        }
        

        public void RegisterObject(WrappedSpaceObject spaceObject)
        {
            _wrappedSpaceObjects.Add(spaceObject);
        }

        public void DeregisterObject(WrappedSpaceObject spaceObject)
        {
            _wrappedSpaceObjects.Remove(spaceObject);
        }
    }
}