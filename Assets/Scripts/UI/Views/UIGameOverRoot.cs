using UnityEngine;

public class UIGameOverRoot : UIRoot
{
    [SerializeField]
    private UIGameOverView gameOverView;
    public UIGameOverView GameOverView => gameOverView;

    public override void ShowRoot()
    {
        base.ShowRoot();

        gameOverView.ShowView();
    }

    public override void HideRoot()
    {
        gameOverView.HideView();

        base.HideRoot();
    }
}
