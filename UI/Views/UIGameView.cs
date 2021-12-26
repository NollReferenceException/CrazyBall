using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UIGameView : UIView
{
    [SerializeField]
    private TextMeshProUGUI gemCountLabel;

    public UnityAction OnReplayClicked;

    public void ReplayClick()
    {
        OnReplayClicked?.Invoke();
    }

    // Event called when Menu Button is clicked.
    public UnityAction OnMenuClicked;

    public void MenuClicked()
    {
        OnMenuClicked?.Invoke();
    }

    public void ShowScore(GameData gameData)
    {
        gemCountLabel.text = gameData.gemCount.ToString("N0");
    }
}