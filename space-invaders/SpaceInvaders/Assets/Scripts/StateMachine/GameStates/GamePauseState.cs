using UnityEngine;

public class GamePauseState : GameBaseState
{
    public override void EnterState()
    {
        base.EnterState();

        Time.timeScale = 0;

        game.UI.GamePauseView.OnExitClicked += ExitClicked;
        game.UI.GamePauseView.OnResumeClicked += ResumeClicked;

        game.UI.GamePauseView.ShowView();
    }
    public override void UpdateState()
    {

    }
    public override void DestroyState()
    {
        game.UI.GamePauseView.HideView();

        game.UI.GamePauseView.OnExitClicked -= ExitClicked;
        game.UI.GamePauseView.OnResumeClicked -= ResumeClicked;

        Time.timeScale = 1;

        base.DestroyState();
    }

    public void ResumeClicked()
    {
        game.SwitchState(new GameMainState { loadGameContent = false });
    }

    public void ExitClicked()
    {
        Application.Quit();
    }
}
