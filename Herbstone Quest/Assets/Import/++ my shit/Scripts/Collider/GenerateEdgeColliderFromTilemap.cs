using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GenerateEdgeColliderFromTilemap : MonoBehaviour
{
    public Tilemap tilemap;
    public EdgeCollider2D edgeCollider;
    private PolygonCollider2D polygonCollider;

    private void Start()
    {
        if (!tilemap)
        {
            tilemap = GetComponent<Tilemap>();
        }

        if (!edgeCollider)
        {
            edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        }

        if (!polygonCollider)
        {
            polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
            polygonCollider.isTrigger = true;
        }

        CreatePolygonColliderFromTilemap(tilemap, polygonCollider);
        CreateEdgeColliderFromPolygon(polygonCollider, edgeCollider);

        // Disable the PolygonCollider2D and TilemapCollider2D
        polygonCollider.enabled = false;
        tilemap.GetComponent<TilemapCollider2D>().enabled = false;
    }

    private void CreatePolygonColliderFromTilemap(Tilemap tilemap, PolygonCollider2D polygonCollider)
    {
        // Get the bounds of the tilemap
        BoundsInt bounds = tilemap.cellBounds;

        List<Vector2> path = new List<Vector2>();

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                if (tilemap.HasTile(tilePos))
                {
                    // Get the world position of the tile
                    Vector3 tileWorldPos = tilemap.CellToWorld(tilePos);

                    // Add the corners of the tile to the path
                    path.Add(tileWorldPos + new Vector3(-tilemap.cellSize.x / 2f, -tilemap.cellSize.y / 2f));
                    path.Add(tileWorldPos + new Vector3(tilemap.cellSize.x / 2f, -tilemap.cellSize.y / 2f));
                    path.Add(tileWorldPos + new Vector3(tilemap.cellSize.x / 2f, tilemap.cellSize.y / 2f));
                    path.Add(tileWorldPos + new Vector3(-tilemap.cellSize.x / 2f, tilemap.cellSize.y / 2f));
                }
            }
        }

        // Set the path to the polygon collider
        polygonCollider.SetPath(0, path.ToArray());
    }

    private void CreateEdgeColliderFromPolygon(PolygonCollider2D polygonCollider, EdgeCollider2D edgeCollider)
    {
        // Get the points from the polygon collider
        Vector2[] points = polygonCollider.points;

        // Set the points to the edge collider
        edgeCollider.points = points;
    }
}
