using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    [SerializeField] private int generateRange;
    [SerializeField] private int clusterSize;
    [SerializeField] private int startPlatformSize;

    Vector3 _direction = Vector3.zero;
    Vector3 _currentPosition = Vector3.zero;
    private Vector3 _generateStep;
    private GemGenerator _gemGenerator;


    private enum DirectionVariant
    {
        Forward,
        Right
    }

    private void Start()
    {
        _gemGenerator = GameObject.Find("GemGenerator").GetComponent<GemGenerator>();
        
        GenerateRoad();
    }

    private void GenerateRoad()
    {
        GetGenerateStep();

        GenerateStartingPlatform();
        SwitchDirection();
        GenerateFirstCluster();

        GenerateClusters();
    }

    public void GenerateClusters()
    {
        for (int i = 0; i < generateRange; i++)
        {
            SwitchDirection();
            
            _currentPosition += Vector3.Scale(_direction, _generateStep * clusterSize);

            GameObject cluster = new GameObject("Cluster");
            TilesCluster tilesCluster = cluster.AddComponent<TilesCluster>();

            tilesCluster.GenerateCluster(clusterSize, _currentPosition, tile);
            
            _gemGenerator.TryCreateGem(tilesCluster.CenterPlatform);

            if (i == generateRange / 2)
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