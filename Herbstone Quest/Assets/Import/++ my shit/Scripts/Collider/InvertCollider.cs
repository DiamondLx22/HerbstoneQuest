using UnityEngine;

public class InvertCollider : MonoBehaviour
{
    public PolygonCollider2D polygonCollider2D;
    public EdgeCollider2D edgeCollider2D;

    private void Start()
    {
        if (!polygonCollider2D)
        {
            polygonCollider2D = GetComponent<PolygonCollider2D>();
        }

        if (!edgeCollider2D)
        {
            edgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
        }

        CreateEdgeColliderFromPolygon(polygonCollider2D, edgeCollider2D);
        polygonCollider2D.enabled = false; // Disable the PolygonCollider2D
    }

    private void CreateEdgeColliderFromPolygon(PolygonCollider2D polygon, EdgeCollider2D edge)
    {
        // Get the paths from the PolygonCollider2D
        int pathCount = polygon.pathCount;

        // Create a list to store all points
        System.Collections.Generic.List<Vector2> points = new System.Collections.Generic.List<Vector2>();

        for (int i = 0; i < pathCount; i++)
        {
            Vector2[] pathPoints = polygon.GetPath(i);
            points.AddRange(pathPoints);
        }

        // Ensure the first and last points are the same
        if (points.Count > 0)
        {
            points.Add(points[0]);
        }

        // Set the points to the EdgeCollider2D
        edge.points = points.ToArray();
    }
}