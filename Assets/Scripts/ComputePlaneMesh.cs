using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputePlaneMesh : MonoBehaviour
{

    [SerializeField] private MeshFilter mF;
    [SerializeField] private MeshRenderer mR;

    [SerializeField] private Vector2Int size;

    private Mesh mesh;

    private Vector3[] vertices;
    private int[] triangles;
    private Vector2[] uv;

    private void Start()
    {
        transform.position = new Vector3(-size.x/2, 0, -size.y/2);
        mesh = new Mesh();
        mF.mesh = mesh;

        CreateShape();
        UpdateShape();
    }

    private void CreateShape()
    {
        vertices = new Vector3[(size.x + 1) * (size.y + 1)];

        for (int y = 0, i = 0; y <= size.y; y++)
        {
            for (int x = 0; x <= size.x; x++)
            {
                vertices[i] = new Vector3(x, 0, y);
                i++;
            }
        }

        triangles = new int[size.x * size.y * 6];

        for (int y = 0, vert = 0, tris=0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                triangles[tris] = vert;
                triangles[tris + 1] = vert + size.x + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + size.x + 1;
                triangles[tris + 5] = vert + size.x + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }
        uv = new Vector2[vertices.Length];

        for (int y = 0, i = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                uv[i] = new Vector2(x / size.x, y / size.y);
                i++;
            }
        }
        
    }

    void UpdateShape()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        mesh.RecalculateNormals();
    }
}
