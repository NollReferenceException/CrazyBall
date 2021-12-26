using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameRestarter _gameRestarter;
    
    public GameRestarter GameRestarter
    {
        get
        {
            if (!_gameRestarter)
            {
                _gameRestarter = GetComponentInChildren<GameRestarter>();
            }
            
            return _gameRestarter;
        }
    }
}