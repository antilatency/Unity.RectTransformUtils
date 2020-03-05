using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Antilatency {
    [ExecuteAlways]
    [RequireComponent(typeof(Camera))]
    public class MotionParallaxCamera : MonoBehaviour {
        public RectTransform display;

        void Start() { }
        void Update() { }

        void OnPreCull() {
            //if (!display) return;
            var camera = GetComponent<Camera>();
            //if (!camera) return;
            transform.localPosition = Vector3.zero;
            transform.rotation = display.rotation;

            Vector3[] corners = new Vector3[4];
            display.GetWorldCorners(corners);

            var min = transform.InverseTransformPoint(corners[0]);
            var max = transform.InverseTransformPoint(corners[2]);

            camera.projectionMatrix = PerspectiveOffCenter(
                min.x / min.z, max.x / max.z,
                min.y / min.z, max.y / max.z
                , camera.nearClipPlane, camera.farClipPlane);

        }

        static Matrix4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far) {
            float x = 2.0F / (right - left);
            float y = 2.0F / (top - bottom);
            float a = (right + left) / (right - left);
            float b = (top + bottom) / (top - bottom);
            float c = -(far + near) / (far - near);
            float d = -(2.0F * far * near) / (far - near);
            float e = -1.0F;
            Matrix4x4 m = Matrix4x4.zero;
            m[0, 0] = x;
            m[0, 2] = a;
            m[1, 1] = y;
            m[1, 2] = b;
            m[2, 2] = c;
            m[2, 3] = d;
            m[3, 2] = e;
            return m;
        }
    }
}
