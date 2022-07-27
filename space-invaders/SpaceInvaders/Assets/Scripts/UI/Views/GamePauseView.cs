using UnityEngine;
using UnityEngine.Events;

public class GamePauseView : BaseView
{
    public UnityAction OnResumeClicked;
    public UnityAction OnExitClicked;

    public void ResumeClick()
    {
        OnResumeClicked?.Invoke();
    }

    public void ExitClick()
    {
        OnExitClicked?.Invoke();
    }
}
