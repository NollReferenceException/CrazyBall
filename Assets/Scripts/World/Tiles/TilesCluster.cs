using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesCluster : MonoBehaviour
{
    public Vector3 CenterPlatform => _centerPlatform;

    private Vector3 _position;
    private Vector3 _tileSize;
    private Vector3 _centerPlatform;

    private Bounds _tileBounds;

    private GameObject[] _tilesArray;
    private GameObject _partCluster;

    private bool _triggerCluster;

    void GetTileBounds()
    {
        GameObject tempTile = Instantiate(_partCluster, Vector3.up * 1000.0f, Quaternion.identity);
        _tileBounds = tempTile.GetComponent<BoxCollider>().bounds;
        Destroy(tempTile);
    }

    public void GenerateCluster(int size, Vector3 position, GameObject partCluster)
    {
        _partCluster = partCluster;
        GetTileBounds();

        _tilesArray = new GameObject[size * size];

        int index = 0;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Vector3 offset = new Vector3(_tileBounds.size.x * i, position.y,
                    _tileBounds.size.z * j);

                _tilesArray[index] = Instantiate(_partCluster, position + offset, Quaternion.identity);
                _tilesArray[index].transform.SetParent(this.transform);

                index++;
            }
        }

        GetPlatformCenter();
    }

    public void SetRegenerateRoadTrigger()
    {
        gameObject.name = "Trigger Cluster";

        for (int i = 0; i < _tilesArray.Length; i++)
        {
            _tilesArray[i].GetComponent<Tile>().TriggerTile = true;
        }
    }

    private void GetPlatformCenter()
    {
        Bounds firstBounds = _tilesArray[0].GetComponent<Collider>().bounds;

        float maxX = firstBounds.max.x;
        float minX = firstBounds.min.x;
        float maxZ = firstBounds.max.z;
        float minZ = firstBounds.min.z;
        float maxY = firstBounds.max.y;

        for (int i = 0; i < _tilesArray.Length; i++)
        {
            Bounds bounds = _tilesArray[i].GetComponent<Collider>().bounds;

            if (bounds.max.x > maxX)
            {
                maxX = bounds.max.x;
            }

            if (bounds.min.x < minX)
            {
                minX = bounds.min.x;
            }

            if (bounds.max.z > maxZ)
            {
                maxZ = bounds.max.z;
            }

            if (bounds.min.z < minZ)
            {
                minZ = bounds.min.z;
            }
        }

        float centerX = maxX - ((maxX - minX) / 2);
        float centerZ = maxZ - ((maxZ - minZ) / 2);

        Vector3 centerPlatform = new Vector3(centerX, maxY, centerZ);

        _centerPlatform = centerPlatform;
    }
}