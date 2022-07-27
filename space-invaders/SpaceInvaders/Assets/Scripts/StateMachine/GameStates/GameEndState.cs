using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndState : GameBaseState
{
    public override void EnterState()
    {
        base.EnterState();
        game.UI.GameEndView.OnReplayClicked += ReplayClicked;
        game.UI.GameEndView.OnExitClicked += ExitClicked;
        game.UI.GameEndView.ShowView();
    }
    public override void UpdateState()
    {

    }
    public override void DestroyState()
    {
        game.UI.GameEndView.HideView();
        game.UI.GameEndView.OnReplayClicked -= ReplayClicked;
        game.UI.GameEndView.OnExitClicked -= ExitClicked;
        base.DestroyState();
    }
    private void ReplayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitClicked()
    {
        Application.Quit();
    }
}
