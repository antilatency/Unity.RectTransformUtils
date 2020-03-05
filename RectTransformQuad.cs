using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class RectTransformQuad : MonoBehaviour{

    private Mesh mesh;
    public Material material;
    private Vector3[] corners = new Vector3[4];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*bool checkChanges() {
        var component = GetComponent<RectTransform>();
        Vector3[] newCorners = new Vector3[4];
        component.GetLocalCorners(newCorners);
        for (int i = 0; i < 4; i++) {
            if (corners[i] != newCorners[i]) {
                corners = newCorners;
                return true;
            }
        }
        return false;
    }*/

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
    void Update(){

        updateQuad();

        /*var component = GetComponent<RectTransform>();
        if (component.hasChanged) {
            Debug.Log("component.hasChanged");
            component.hasChanged = false;
        }*/


        Graphics.DrawMesh(mesh, GetComponent<RectTransform>().ToMatrix(), material, 0);
    }

}
