using System.Collections.Generic;
using UnityEngine;

namespace Wrapper
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
            Bounds cameraBounds = GetCameraBoundingBox();

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

        private Bounds GetCameraBoundingBox()
        {
            Vector3[] corners = new Vector3[8];
            _camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), _camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, corners);
            return GeometryUtility.CalculateBounds(corners, Matrix4x4.identity);
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