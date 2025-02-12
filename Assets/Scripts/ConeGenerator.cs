using UnityEngine;

[ExecuteInEditMode] // Permet d'exécuter le script dans l'éditeur
public class ConeGenerator : MonoBehaviour
{
    public int segments = 20;
    public float radius = 1f;
    public float height = 2f;

    public Material m_red;

    private MeshFilter meshFilter;

    void OnValidate()
    {
        GenerateCone();
    }

    void GenerateCone()
    {
        if (meshFilter == null)
            meshFilter = GetComponent<MeshFilter>() ?? gameObject.AddComponent<MeshFilter>();

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>() ?? gameObject.AddComponent<MeshRenderer>();

        Mesh coneMesh = CreateConeMesh(segments, radius, height);
        meshFilter.sharedMesh = coneMesh;

        if (m_red != null)
        {
            meshRenderer.sharedMaterial = m_red;
        }
        else
        {
            // Si m_red n'est pas assigné, tu peux appliquer un matériau par défaut ou en créer un ici
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshRenderer.sharedMaterial.color = Color.red;
        }

        // Ajouter un MeshCollider pour correspondre exactement au cône
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>() ?? gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = coneMesh;
        meshCollider.convex = true; // Convexe pour l'utiliser en physique
    }

    Mesh CreateConeMesh(int segments, float radius, float height)
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[segments + 2];
        int[] triangles = new int[segments * 3 * 2];

        vertices[0] = Vector3.zero; // Sommet du cône
        vertices[segments + 1] = new Vector3(0, -height, 0); // Centre de la base

        float angleStep = 2 * Mathf.PI / segments;
        for (int i = 0; i < segments; i++)
        {
            float angle = i * angleStep;
            vertices[i + 1] = new Vector3(Mathf.Cos(angle) * radius, -height, Mathf.Sin(angle) * radius);
        }

        for (int i = 0; i < segments; i++)
        {
            int nextIndex = (i + 1) % segments + 1;

            // Triangle entre le sommet et la base
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = nextIndex;
            triangles[i * 3 + 2] = i + 1;

            // Triangle de la base
            triangles[(segments + i) * 3] = segments + 1;
            triangles[(segments + i) * 3 + 1] = i + 1;
            triangles[(segments + i) * 3 + 2] = nextIndex;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}
