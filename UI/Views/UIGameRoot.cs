using UnityEngine;


public class UIGameRoot : UIBase
{
    // Reference to game over view class.
    [SerializeField]
    private UIGameView gameOverView;
    public UIGameView GameOverView => gameOverView;

    public override void ShowRoot()
    {
        base.ShowRoot();

        gameOverView.Show();
    }

    public override void HideRoot()
    {
        gameOverView.Hide();

        base.HideRoot();
    }
}