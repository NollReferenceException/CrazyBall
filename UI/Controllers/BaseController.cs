using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [HideInInspector]
    public RootController root;
   
    public virtual void EngageController()
    {
        gameObject.SetActive(true);
    }

    public virtual void DisengageController()
    {
        gameObject.SetActive(false);
    }
}

public abstract class BaseController<T> : BaseController where T : UIBase
{
    [SerializeField]
    protected T ui;
    public T UI => ui;

    public override void EngageController()
    {
        base.EngageController();

        ui.ShowRoot();
    }

    public override void DisengageController()
    {
        base.DisengageController();

        ui.HideRoot();
    }
}