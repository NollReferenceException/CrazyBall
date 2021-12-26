
public class GameController : BaseController<UIGameRoot>
{
    private ScoreData _scoreData;
    private Player _player;

    public override void ActivateController()
    {
        _scoreData = new ScoreData();

        if (_player == null)
        {
            _player = MainCharacters.Instance.Player;
        }
        
        _player.PickUpGemAction += ChangeScore;
        _player.PlayerDead += LoseGame;

        base.ActivateController();
    }

    public override void DeactivateController()
    {
        base.DeactivateController();

        if (_player == null)
        {
            _player = MainCharacters.Instance.Player;
        }
        
        _player.PickUpGemAction -= ChangeScore;
        _player.PlayerDead -= LoseGame;
    }

    private void LoseGame()
    {
        _scoreData.ZeroingScore();
        uiElement.GameView.ShowScore(_scoreData);
        
        root.ChangeController(RootController.ControllerTypeEnum.GameOver);
    }

    private void ChangeScore()
    {
        _scoreData.IncreaseScore();
        uiElement.GameView.ShowScore(_scoreData);
    }
}
