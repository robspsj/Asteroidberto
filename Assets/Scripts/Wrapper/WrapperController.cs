using System.Collections.Generic;
using UnityEngine;

namespace Asteroidsberto.Wrapper
{
    public class WrapperSpaceController : MonoBehaviour
    {
        private readonly List<WrappedSpaceObject> _wrappedSpaceObjects = new();

        private const float AspectRatio = 16f / 9;

        private void FixedUpdate()
        {
            foreach (WrappedSpaceObject spaceObject in _wrappedSpaceObjects)
            {
                if (spaceObject.Transform.position.x < -5 * AspectRatio)
                    spaceObject.Transform.position += Vector3.right * (10 * AspectRatio);
                if (spaceObject.Transform.position.x > 5 * AspectRatio)
                    spaceObject.Transform.position += Vector3.left * (10 * AspectRatio);
                if (spaceObject.Transform.position.y < -5)
                    spaceObject.Transform.position += Vector3.up * 10;
                if (spaceObject.Transform.position.y > 5)
                    spaceObject.Transform.position += Vector3.down * 10;
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