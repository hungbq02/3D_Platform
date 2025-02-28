using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject tilePrefab;
    public float offsetY = 1.0f;
    public GameObject parent;

    void Start()
    {
        parent = GameObject.Find("TileSpawn");
        SpawnTilesBelow();
    }

    void SpawnTilesBelow()
    {
        if (tilePrefab == null)
        {
            return;
        }

        Vector3 currentPos = transform.position;

        // Tạo 2 tile bên dưới
        Instantiate(tilePrefab, currentPos + new Vector3(0, -offsetY, 0), Quaternion.identity, parent.transform);
        Instantiate(tilePrefab, currentPos + new Vector3(0, -2 * offsetY, 0), Quaternion.identity, parent.transform);
    }
}
