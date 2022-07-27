using UnityEngine;

public class GameMainState : GameBaseState
{
    public bool loadGameContent = true;
    public bool destroyGameContent = true;

    public override void EnterState()
    {
        base.EnterState();

        game.UI.GameMainView.OnPauseClicked += PauseClicked;

        game.UI.GameMainView.ShowView();
        

        if(loadGameContent)
        {

        }
    }
    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseClicked();
        }
    }
        public override void DestroyState()
    {
        if(destroyGameContent)
        {

        }

        game.UI.GameMainView.HideView();

        game.UI.GameMainView.OnPauseClicked -= PauseClicked;

        base.DestroyState();
    }

    private void PauseClicked()
    {
        destroyGameContent = false;
        game.SwitchState(new GamePauseState());
    }
}