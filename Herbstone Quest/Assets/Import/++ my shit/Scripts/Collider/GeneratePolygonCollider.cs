using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GeneratePolygonCollider : MonoBehaviour
{
    public Tilemap tilemap;
    private PolygonCollider2D polygonCollider;

    private void Start()
    {
        if (!tilemap)
        {
            tilemap = GetComponent<Tilemap>();
        }

        if (!polygonCollider)
        {
            polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
        }

        CreatePolygonColliderFromTilemap(tilemap, polygonCollider);
    }

    private void CreatePolygonColliderFromTilemap(Tilemap tilemap, PolygonCollider2D polygonCollider)
    {
        List<Vector2> outlinePoints = GetOutlinePoints(tilemap);
        if (outlinePoints.Count > 0)
        {
            polygonCollider.SetPath(0, outlinePoints.ToArray());
        }
    }

    private List<Vector2> GetOutlinePoints(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;
        List<Vector2> outlinePoints = new List<Vector2>();
        HashSet<Vector3Int> visited = new HashSet<Vector3Int>();

        Vector3Int startPoint = GetStartPoint(tilemap, bounds);
        if (startPoint == new Vector3Int(int.MinValue, int.MinValue, int.MinValue))
        {
            return outlinePoints;
        }

        Vector3Int currentPoint = startPoint;
        Vector3Int[] directions = new Vector3Int[]
        {
            new Vector3Int(1, 0, 0),
            new Vector3Int(0, 1, 0),
            new Vector3Int(-1, 0, 0),
            new Vector3Int(0, -1, 0)
        };

        int directionIndex = 0;

        do
        {
            visited.Add(currentPoint);
            Vector3Int nextPoint = currentPoint + directions[directionIndex];

            if (tilemap.HasTile(nextPoint))
            {
                if (directionIndex == 0) // Right
                {
                    outlinePoints.Add(tilemap.CellToWorld(currentPoint) + new Vector3(0.5f, 0.5f));
                    outlinePoints.Add(tilemap.CellToWorld(currentPoint) + new Vector3(0.5f, -0.5f));
                }
                else if (directionIndex == 1) // Up
                {
                    outlinePoints.Add(tilemap.CellToWorld(currentPoint) + new Vector3(0.5f, 0.5f));
                    outlinePoints.Add(tilemap.CellToWorld(currentPoint) + new Vector3(-0.5f, 0.5f));
                }
                else if (directionIndex == 2) // Left
                {
                    outlinePoints.Add(tilemap.CellToWorld(currentPoint) + new Vector3(-0.5f, 0.5f));
                    outlinePoints.Add(tilemap.CellToWorld(currentPoint) + new Vector3(-0.5f, -0.5f));
                }
                else if (directionIndex == 3) // Down
                {
                    outlinePoints.Add(tilemap.CellToWorld(currentPoint) + new Vector3(0.5f, -0.5f));
                    outlinePoints.Add(tilemap.CellToWorld(currentPoint) + new Vector3(-0.5f, -0.5f));
                }
                currentPoint = nextPoint;
            }
            else
            {
                directionIndex = (directionIndex + 1) % 4;
            }
        }
        while (currentPoint != startPoint);

        return outlinePoints;
    }

    private Vector3Int GetStartPoint(Tilemap tilemap, BoundsInt bounds)
    {
        for (int y = bounds.yMin; y < bounds.yMax; y++)
        {
            for (int x = bounds.xMin; x < bounds.xMax; x++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                if (tilemap.HasTile(tilePos))
                {
                    return tilePos;
                }
            }
        }
        // Return a sentinel value indicating no start point was found
        return new Vector3Int(int.MinValue, int.MinValue, int.MinValue);
    }
}
