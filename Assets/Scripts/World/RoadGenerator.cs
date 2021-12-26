using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadGenerator : MonoBehaviour
{
    public GameObject tile;
    public int generateRange;
    public int clusterSize;
    public int startPlatformSize;
    Vector3 _direction = Vector3.zero;
    Vector3 _currentPosition = Vector3.zero;
    private Vector3 _generateStep;


    private enum DirectionVariant
    {
        Forward,
        Right
    }

    private void Start()
    {
        GenerateRoad();
    }

    private void GenerateRoad()
    {
        GetGenerateStep();

        GenerateStartingPlatform();
        SwitchDirection();
        GenerateFirstCluster();

        GenerateClusters(generateRange);
    }

    public void GenerateClusters(int clustersCount)
    {
        for (int i = 0; i < clustersCount; i++)
        {
            SwitchDirection();

            _currentPosition += Vector3.Scale(_direction, _generateStep * clusterSize);

            GameObject cluster = new GameObject("Cluster");
            TilesCluster tilesCluster = cluster.AddComponent<TilesCluster>();

            tilesCluster.GenerateCluster(clusterSize, _currentPosition, tile);

            if (i == clustersCount / 2)
            {
                tilesCluster.SetRegenerateRoadTrigger();
            }
        }
    }

    void GenerateStartingPlatform()
    {
        GameObject startingPlatform = new GameObject("Starting Platform");
        TilesCluster startingTilesPlatform = startingPlatform.AddComponent<TilesCluster>();

        startingTilesPlatform.GenerateCluster(startPlatformSize, _currentPosition, tile);
    }

    void GenerateFirstCluster()
    {
        GameObject firstCluster = new GameObject("First Cluster");
        TilesCluster firstTilesCluster = firstCluster.AddComponent<TilesCluster>();

        _currentPosition += Vector3.Scale(_direction, _generateStep * startPlatformSize);

        firstTilesCluster.GenerateCluster(clusterSize, _currentPosition, tile);
    }

    void SwitchDirection()
    {
        int directionSwitcher = Random.Range(0, 2);

        switch (directionSwitcher)
        {
            case (int) DirectionVariant.Forward:
                _direction = Vector3.forward;
                break;
            case (int) DirectionVariant.Right:
                _direction = Vector3.right;
                break;
        }
    }

    void GetGenerateStep()
    {
        GameObject tempTile = Instantiate(tile, Vector3.up * 1000.0f, Quaternion.identity);
        Bounds tileBounds = tempTile.GetComponent<BoxCollider>().bounds;
        _generateStep = new Vector3(tileBounds.size.x, 0, tileBounds.size.z);
        Destroy(tempTile);
    }
}