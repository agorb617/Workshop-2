using UnityEngine;
using System.Collections;

public class PyramidScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        // Add a MeshFilter component to this entity. This essentially comprises of a
        // mesh definition, which in this example is a collection of vertices, colours 
        // and triangles (groups of three vertices). 
        MeshFilter cubeMesh = this.gameObject.AddComponent<MeshFilter>();
        cubeMesh.mesh = this.CreateCubeMesh();

        // Add a MeshRenderer component. This component actually renders the mesh that
        // is defined by the MeshFilter component.
        MeshRenderer renderer = this.gameObject.AddComponent<MeshRenderer>();
        renderer.material.shader = Shader.Find("Unlit/VertexColorShader");
    }

    // Method to create a cube mesh with coloured vertices
    Mesh CreateCubeMesh()
    {
        Mesh m = new Mesh();
        m.name = "Cube";

        // Define the vertices. These are the "points" in 3D space that allow us to
        // construct 3D geometry (by connecting groups of 3 points into triangles).
        m.vertices = new[] {

            new Vector3(-1.0f, -1.0f, -1.0f), // Bottom
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),

            new Vector3(-1.0f, -1.0f, -1.0f), // Left
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(0f, 1f, 0f),

            new Vector3(1.0f, -1.0f, 1.0f), // Right
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(0f, 1f, 0f),

            new Vector3(1.0f, -1.0f, -1.0f), // Front
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(0f, 1f, 0f),

            new Vector3(-1.0f, -1.0f, 1.0f), // Backsw
            new Vector3(1.0f, -1.0f, 1.0f), 
            new Vector3(0f, 1f, 0f)

            // Task 2: Define vertices for front and back faces
            // Remember to also define corresponding vertex colours!
        };

        // Define the vertex colours
        m.colors = new[] {

            Color.green, // Bottom
            Color.green,
            Color.green,
            Color.green,
            Color.green,
            Color.green,

            Color.yellow, // Left
            Color.yellow,
            Color.yellow,


            Color.blue, // Right
            Color.blue,
            Color.blue,


            Color.grey, // Front
            Color.grey,
            Color.grey,


            Color.black, // Back
            Color.black,
            Color.black

        };

        // Automatically define the triangles based on the number of vertices
        // Task 4: Modify this code to show the interior of the cube instead of the exterior
        // when back-face culling is on.
        int[] triangles = new int[m.vertices.Length];
        for (int i = 0; i < m.vertices.Length; i++){
            triangles[i] = i;
        }

        m.SetTriangles(triangles,0);

        return m;
    }
}
