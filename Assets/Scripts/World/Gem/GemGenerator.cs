using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class GemGenerator : MonoBehaviour, IRestartable
{
    [SerializeField] private int gemGenerationPattern;
    [SerializeField] private int gemSpawnInterval;
    [SerializeField] private GameObject gem;

    private float _height = 0.7f;
    private int _currentCluster = 0;
    private int _currentBlockCluster = 0;
    private Vector3 _platformCenter;
    private int _targetPlatform;

    private List<GameObject> _allGems;

    private enum GenerationPattern
    {
        Orderly,
        Random
    }

    private void Start()
    {
        Reset();
    }

    public void TryCreateGem(Vector3 platformCenter)
    {
        _platformCenter = platformCenter;

        switch (gemGenerationPattern)
        {
            case (int) GenerationPattern.Orderly:
                OrderlySpawning();
                break;
            case (int) GenerationPattern.Random:
                RandomSpawning();
                break;
            default:
                OrderlySpawning();
                break;
        }
    }

    void RandomSpawning()
    {
        if (_currentCluster == _targetPlatform)
        {
            SpawnGem();
        }

        _currentCluster++;

        if (_currentCluster > gemSpawnInterval - 1)
        {
            _currentCluster = 0;
            _targetPlatform = Random.Range(0, gemSpawnInterval);
        }
    }

    void OrderlySpawning()
    {
        if (_currentCluster == _currentBlockCluster)
        {
            SpawnGem();
        }

        _currentCluster++;

        if (_currentCluster > gemSpawnInterval - 1)
        {
            _currentCluster = 0;

            if (_currentBlockCluster < gemSpawnInterval - 1)
            {
                _currentBlockCluster++;
            }
            else
            {
                _currentBlockCluster = 0;
            }
        }
    }

    void Reset()
    {
        _height = 0.7f;
        _currentCluster = 0;
        _currentBlockCluster = 0;
        _targetPlatform = Random.Range(0, gemSpawnInterval);
        _allGems = new List<GameObject>();
    }

    void SpawnGem()
    {
        _allGems.Add(Instantiate(gem, _platformCenter + Vector3.up * _height, Quaternion.identity));
    }

    public void RestartThisObject()
    {
        foreach (var gemToDestroy in _allGems)
        {
            Destroy(gemToDestroy);
        }

        Reset();
    }
}