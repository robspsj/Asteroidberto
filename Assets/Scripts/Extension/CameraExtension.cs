using UnityEngine;

namespace Extension
{
    public static class CameraExtension
    {
        public static Bounds GetCameraBoundingBox(this Camera camera)
        {
            Vector3[] corners = new Vector3[8];
            camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, corners);
            return GeometryUtility.CalculateBounds(corners, Matrix4x4.identity);
        }
    }
}