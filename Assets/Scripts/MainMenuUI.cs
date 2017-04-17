using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {

    private HighScoreWindow highScoreWindow;

    private void Awake()
    {
        highScoreWindow = GetComponentInChildren<HighScoreWindow>(true);
        highScoreWindow.Init();
    }

    public void OnNewGamePressed()
    {
        GameGlobals.Instance.stateManager.ChangeState(GameState.StateType.Game, "Level1");
    }

    public void OnQuitGamePressed()
    {
        Application.Quit();
    }

    public void OnHighScorePressed()
    {
        highScoreWindow.OpenWindow();
    }

    public void OnBackPressed()
    {
        highScoreWindow.CloseWindow();
    }
}
