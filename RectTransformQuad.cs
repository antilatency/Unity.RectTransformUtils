using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Antilatency {
    [ExecuteAlways]
    public class RectTransformQuad : MonoBehaviour {

        private Mesh mesh;
        public Material material;
        private Vector3[] corners = new Vector3[4];


        // Start is called before the first frame update
        void Start() {

        }

        void updateQuad() {
            if (!mesh) {
                mesh = new Mesh();
                mesh.vertices = new Vector3[] {
                    new Vector2(-1, -1),
                    new Vector2(-1, 1),
                    new Vector2(1, 1),
                    new Vector2(1, -1)
                };
                mesh.triangles = new int[] { 0, 1, 2, 2, 3, 0 };
                mesh.normals = new Vector3[] { -Vector3.forward, -Vector3.forward, -Vector3.forward, -Vector3.forward };
                mesh.uv = new Vector2[] { Vector2.zero, new Vector2(0, 1), Vector2.one, new Vector2(1, 0) };
                mesh.RecalculateTangents();
            }
        }


        // Update is called once per frame
        void Update() {
            updateQuad();
            Graphics.DrawMesh(mesh, GetComponent<RectTransform>().ToMatrix(), material, 0);
        }

    }
}