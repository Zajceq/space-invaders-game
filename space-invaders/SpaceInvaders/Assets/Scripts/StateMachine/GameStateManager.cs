using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameBaseState currentState;

    [SerializeField]
    private UIController ui;
    public UIController UI => ui;
    void Start()
    {
        SwitchState(new GameIntroState());
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void SwitchState(GameBaseState newState)
    {
        if (currentState != null)
        {
            currentState.DestroyState();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.game = this;
            currentState.EnterState();
        }
    }
}
