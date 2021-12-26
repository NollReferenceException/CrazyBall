using UnityEngine;

public class ScoreData
{
    private int _gameScore;

    public int GameScore => _gameScore;

    public ScoreData()
    {
        _gameScore = 0;
    }

    public void ZeroingScore()
    {
        _gameScore = 0;
    }

    public void IncreaseScore()
    {
        _gameScore++;
    }
}
