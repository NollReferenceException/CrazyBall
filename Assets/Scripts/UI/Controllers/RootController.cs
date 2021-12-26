using UnityEngine;



public class RootController : MonoBehaviour
{
    public enum ControllerTypeEnum
    {
        Game,
        GameOver
    }

    [Header("Controllers")]
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameOverController gameOverController;

    private void Start()
    {
        gameController.root = this;
        gameOverController.root = this;

        ChangeController(ControllerTypeEnum.Game);
    }

    public void ChangeController(ControllerTypeEnum controller)
    {
        DeactivateControllers();

        switch (controller)
        {
            case ControllerTypeEnum.Game:
                gameController.ActivateController();
                break;
            case ControllerTypeEnum.GameOver:
                gameOverController.ActivateController();
                break;
        }
    }

    public void DeactivateControllers()
    {
        gameController.DeactivateController();
        gameOverController.DeactivateController();
    }
}
