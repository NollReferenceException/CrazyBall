using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [HideInInspector]
    public RootController root;

    public virtual void ActivateController()
    {
        gameObject.SetActive(true);
    }

    public virtual void DeactivateController()
    {
        gameObject.SetActive(false);
    }
}

public abstract class BaseController<T> : BaseController where T : UIRoot
{
    [SerializeField]
    protected T uiElement;
    public T UIElement => uiElement;

    public override void ActivateController()
    {
        base.ActivateController();

        uiElement.ShowRoot();
    }

    public override void DeactivateController()
    {
        base.DeactivateController();

        uiElement.HideRoot();
    }
}
