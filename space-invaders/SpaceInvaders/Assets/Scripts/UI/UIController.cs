using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameIntroView gameIntroView;
    public GameIntroView GameIntroView => gameIntroView;

    [SerializeField]
    private GameMainView gameMainView;
    public GameMainView GameMainView => gameMainView;

    [SerializeField]
    private GamePauseView gamePauseView;
    public GamePauseView GamePauseView => gamePauseView;

    [SerializeField]
    private GameEndView gameEndView;
    public GameEndView GameEndView => gameEndView;
}
