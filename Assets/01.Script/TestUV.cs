using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUV : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }
    void Start()
    {
        Mesh mesh = new Mesh();
        _meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(0, 0);
        vertices[1] = new Vector3(0, 2);
        vertices[2] = new Vector3(2, 2);
        vertices[3] = new Vector3(2, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        _meshFilter.mesh = mesh;
    }
}
