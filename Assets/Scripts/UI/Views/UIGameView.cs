using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class UIGameView : UIView
{
    [SerializeField]
    private TextMeshProUGUI scoreLabel;

    public void ShowScore(ScoreData scoreData)
    {
        scoreLabel.text = scoreData.GameScore.ToString("N0");
    }
}
