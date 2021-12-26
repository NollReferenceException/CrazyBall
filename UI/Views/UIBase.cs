using UnityEngine;

public class UIBase : MonoBehaviour
{
    public virtual void ShowRoot()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideRoot()
    {
        gameObject.SetActive(false);
    }
}