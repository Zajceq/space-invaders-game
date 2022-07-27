using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameEndView : BaseView
{
    public UnityAction OnReplayClicked;
    public UnityAction OnExitClicked;

    public override void ShowView()
    {
        base.ShowView();

    }

    public override void HideView()
    {
        base.HideView();
    }

    public void ReplayClick()
    {
        OnReplayClicked?.Invoke();
    }

    public void ExitClick()
    {
        OnExitClicked?.Invoke();
    }
}