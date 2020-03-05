using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRectTransform : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        
    }




    void OnDrawGizmos(){
        var component = GetComponent<RectTransform>();
        if (!component) return;
        var rect = component.rect;

        Gizmos.matrix = component.localToWorldMatrix;
        Gizmos.DrawLine(rect.min, new Vector2(rect.xMin,rect.yMax));
        Gizmos.DrawLine(new Vector2(rect.xMin,rect.yMax), rect.max);
        Gizmos.DrawLine(rect.max, new Vector2(rect.xMax,rect.yMin));
        Gizmos.DrawLine(new Vector2(rect.xMax,rect.yMin), rect.min);      


        Gizmos.matrix = Matrix4x4.identity;
    }
}
