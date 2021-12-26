using UnityEngine.Events;



public class UIGameOverView : UIView
{
    public UnityAction OnReplayClicked;

    public void ReplayClick()
    {
        OnReplayClicked?.Invoke();
    }
}
