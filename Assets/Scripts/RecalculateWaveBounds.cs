using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class RecalculateWaveBounds : MonoBehaviour
{
    public float boundsScaleFactor;
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.bounds = new Bounds(mesh.bounds.center, mesh.bounds.size*boundsScaleFactor);
        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
