using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIntroState : GameBaseState
{
    public override void EnterState()
    {
        base.EnterState();

        game.UI.GameIntroView.OnStartClicked += StartClicked;
        game.UI.GameIntroView.OnQuitClicked += QuitClicked;

        game.UI.GameIntroView.ShowView();
    }
    public override void UpdateState()
    {

    }
    public override void DestroyState()
    {
        game.UI.GameIntroView.HideView();

        game.UI.GameIntroView.OnStartClicked -= StartClicked;
        game.UI.GameIntroView.OnQuitClicked -= QuitClicked;

        base.DestroyState();
    }
    public void StartClicked()
    {
        game.SwitchState(new GameMainState());
    }

    public void QuitClicked()
    {
        Application.Quit();
    }
}
