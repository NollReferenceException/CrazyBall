using UnityEngine;

/// <summary>
/// Root controller responsible for changing game phases with SubControllers.
/// </summary>
public class RootController : MonoBehaviour
{
    // SubControllers types.
    public enum ControllerTypeEnum
    {
        Game,
        GameOver
    }

    // References to the subcontrollers.
    [Header("Controllers")]
    [SerializeField]
    private GameController gameController;
    // private GameController gameController;

    /// <summary>
    /// Unity method called on first frame.
    /// </summary>
    private void Start()
    {
        // gameController.root = this;
        gameController.root = this;

        ChangeController(ControllerTypeEnum.Game);
        ChangeController(ControllerTypeEnum.GameOver);
    }

    /// <summary>
    /// Method used by subcontrollers to change game phase.
    /// </summary>
    /// <param name="controller">Controller type.</param>
    public void ChangeController(ControllerTypeEnum controller)
    {
        // Reseting subcontrollers.
        DisengageControllers();

        // Enabling subcontroller based on type.
        switch (controller)
        {
           
            case ControllerTypeEnum.Game:
                gameController.EngageController();
                break;
            case ControllerTypeEnum.GameOver:
                gameController.EngageController();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Method used to disable all attached subcontrollers.
    /// </summary>
    public void DisengageControllers()
    {
        gameController.DisengageController();
    }
}