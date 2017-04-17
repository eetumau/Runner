using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_In : GameState {

    private UIController _uiController;
	// Use this for initialization
	void Start () {
        type = GameState.StateType.Game;
        stateName = "Level1";
        base.Start();

        _uiController = FindObjectOfType<UIController>();
	}
	
    void Update()
    {
        if (!GameGlobals.Instance.playerAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _uiController.highScoreSaved)
            {
                GameGlobals.Instance.SetDefaults();
                GameGlobals.Instance.stateManager.ChangeState(StateType.Game, "Level1");
            }

            if (Input.GetKeyDown(KeyCode.Escape) && _uiController.highScoreSaved)
            {
                GameGlobals.Instance.SetDefaults();
                GameGlobals.Instance.stateManager.ChangeState(StateType.MainMenu, "MainMenu");
            }
        }
    }
	
}
