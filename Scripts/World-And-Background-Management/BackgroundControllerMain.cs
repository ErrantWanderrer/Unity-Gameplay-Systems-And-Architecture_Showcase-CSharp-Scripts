
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControllerMain : MonoBehaviour
{
    public GameObject background;
    public GameObject player;
    public Camera gameCamera;

    [Header("Background Settings")]
    public float prefabWidth = 80f;
    public float prefabHeight = 100f;
    public float zPosition = 40f;
    public float margin = 2f;
    public float leftOffset = 60f;

    private Dictionary<Vector2Int, GameObject> spawnedTiles = new Dictionary<Vector2Int, GameObject>();
    private Vector2Int lastCameraTilePos;
    private float cameraOrthoSize;
    private float cameraAspect;

    void Start()
    {
        if (gameCamera == null)
            gameCamera = Camera.main;

        cameraOrthoSize = gameCamera.orthographicSize;
        cameraAspect = gameCamera.aspect;

        UpdateBackground();
    }

    void Update()
    {
        if (player == null) return;

        Vector2Int currentTilePos = GetCameraTilePosition();
        if (currentTilePos != lastCameraTilePos ||
            Mathf.Abs(cameraOrthoSize - gameCamera.orthographicSize) > 0.1f ||
            Mathf.Abs(cameraAspect - gameCamera.aspect) > 0.01f)
        {
            cameraOrthoSize = gameCamera.orthographicSize;
            cameraAspect = gameCamera.aspect;
            UpdateBackground();
            lastCameraTilePos = currentTilePos;
        }
    }

    Vector2Int GetCameraTilePosition()
    {
        if (gameCamera == null) return Vector2Int.zero;

        int tileX = Mathf.RoundToInt((gameCamera.transform.position.x + leftOffset) / prefabWidth);
        int tileY = Mathf.RoundToInt(gameCamera.transform.position.y / prefabHeight);

        return new Vector2Int(tileX, tileY);
    }

    void UpdateBackground()
    {
        if (gameCamera == null || background == null) return;

        float visibleWidth = 2f * cameraOrthoSize * cameraAspect;
        float visibleHeight = 2f * cameraOrthoSize;

        int tilesX = Mathf.CeilToInt((visibleWidth + margin + leftOffset) / prefabWidth);
        int tilesY = Mathf.CeilToInt((visibleHeight + margin) / prefabHeight);

        Vector2Int cameraTilePos = GetCameraTilePosition();

        int startX = cameraTilePos.x - Mathf.FloorToInt(tilesX / 2f);
        int endX = cameraTilePos.x + Mathf.CeilToInt(tilesX / 2f);
        int startY = cameraTilePos.y - Mathf.FloorToInt(tilesY / 2f);
        int endY = cameraTilePos.y + Mathf.CeilToInt(tilesY / 2f);

        HashSet<Vector2Int> neededTiles = new HashSet<Vector2Int>();

        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                neededTiles.Add(new Vector2Int(x, y));
            }
        }

        List<Vector2Int> tilesToRemove = new List<Vector2Int>();
        foreach (Vector2Int tilePos in spawnedTiles.Keys)
        {
            if (!neededTiles.Contains(tilePos))
            {
                if (spawnedTiles[tilePos] != null)
                    Destroy(spawnedTiles[tilePos]);
                tilesToRemove.Add(tilePos);
            }
        }

        foreach (Vector2Int tilePos in tilesToRemove)
        {
            spawnedTiles.Remove(tilePos);
        }

        foreach (Vector2Int tilePos in neededTiles)
        {
            if (!spawnedTiles.ContainsKey(tilePos))
            {
                Vector3 position = new Vector3(
                    tilePos.x * prefabWidth - leftOffset,
                    tilePos.y * prefabHeight,
                    zPosition
                );

                GameObject tile = Instantiate(background, position, Quaternion.identity);
                spawnedTiles.Add(tilePos, tile);
            }
        }
    }
}
