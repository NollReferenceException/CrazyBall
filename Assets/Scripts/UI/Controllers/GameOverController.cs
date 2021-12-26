


public class GameOverController : BaseController<UIGameOverRoot>
{
    private ScoreData _scoreData;

    public override void ActivateController()
    {
        uiElement.GameOverView.OnReplayClicked += ReplayGame;

        base.ActivateController();
    }

    public override void DeactivateController()
    {
        base.DeactivateController();

        uiElement.GameOverView.OnReplayClicked -= ReplayGame;
    }

    private void ReplayGame()
    {
        GameManager.Instance.GameRestarter.Restart();
        
        root.ChangeController(RootController.ControllerTypeEnum.Game);
    }
}
