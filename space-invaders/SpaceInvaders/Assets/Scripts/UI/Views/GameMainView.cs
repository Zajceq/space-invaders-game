using UnityEngine;
using UnityEngine.Events;

public class GameMainView : BaseView
{
    public UnityAction OnPauseClicked;

    public void PauseClick()
    {
        OnPauseClicked?.Invoke();    
    }

}
