using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Antilatency {
    public static class RectTransformUtils {
        public static Matrix4x4 ToMatrix(this RectTransform rectTransform, float scale = 1) {
            Matrix4x4 matrix = rectTransform.localToWorldMatrix;
            matrix *= Matrix4x4.TRS(rectTransform.rect.center, Quaternion.identity, new Vector3(rectTransform.rect.width * 0.5f * scale, rectTransform.rect.height * 0.5f * scale, 1));
            return matrix;
        }

        public static Matrix4x4 ToUVMatrix(this RectTransform rectTransform) {
            Matrix4x4 matrix = rectTransform.localToWorldMatrix;
            matrix *= Matrix4x4.TRS(rectTransform.rect.min, Quaternion.identity, new Vector3(rectTransform.rect.width, rectTransform.rect.height, 1));
            return matrix;
        }
    }
}