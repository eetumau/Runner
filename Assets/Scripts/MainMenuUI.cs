using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {


    public void OnNewGamePressed()
    {
        GameGlobals.Instance.stateManager.ChangeState(GameState.StateType.Game, "Level1");
    }

    public void OnQuitGamePressed()
    {
        Application.Quit();
    }
}
