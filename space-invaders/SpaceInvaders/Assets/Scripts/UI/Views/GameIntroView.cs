using UnityEngine;
using UnityEngine.Events;

public class GameIntroView : BaseView
{
    public UnityAction OnStartClicked;
    public UnityAction OnQuitClicked;

    public void StartClick()
    {
        OnStartClicked?.Invoke();
    }

    public void QuitClick()
    {
        OnQuitClicked?.Invoke();
    }
}
