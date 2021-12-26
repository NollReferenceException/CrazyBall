using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorsManagers : Singleton<GeneratorsManagers>
{
    // public static GeneratorsManagers Instance = null;
    private RoadGenerator _roadGenerator;
    private GemGenerator _gemGenerator;
    
    public RoadGenerator RoadGenerator
    {
        get
        {
            if (!_roadGenerator)
            {
                _roadGenerator = GetComponentInChildren<RoadGenerator>();
            }
            
            return _roadGenerator;
        }
    }
    
    public GemGenerator GemGenerator
    {
        get
        {
            if (!_gemGenerator)
            {
                _gemGenerator = GetComponentInChildren<GemGenerator>();
            }
            
            return _gemGenerator;
        }
    }
    
    // void Start()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //     }
    //     else if (Instance == this)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}