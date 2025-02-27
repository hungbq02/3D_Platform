using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject tilePrefab; // Prefab của tile
    public float offsetY = 1.0f;  // Khoảng cách giữa các tile theo Y
    public GameObject parent;      // Parent của tile

    void Start()
    {
        SpawnTilesBelow();
    }

    void SpawnTilesBelow()
    {
        if (tilePrefab == null)
        {
            Debug.LogError("TilePrefab chưa được gán trong TileSpawner!");
            return;
        }

        // Vị trí của tile hiện tại
        Vector3 currentPos = transform.position;

        // Tạo 2 tile bên dưới
        Instantiate(tilePrefab, currentPos + new Vector3(0, -offsetY, 0), Quaternion.identity);
        Instantiate(tilePrefab, currentPos + new Vector3(0, -2 * offsetY, 0), Quaternion.identity);
    }
}
