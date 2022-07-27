using UnityEngine;

public abstract class GameBaseState
{
    public GameStateManager game;
    public virtual void EnterState() {}
    public virtual void UpdateState() {}
    public virtual void DestroyState() {}
}
