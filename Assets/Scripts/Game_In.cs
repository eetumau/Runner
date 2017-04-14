using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_In : GameState {

	// Use this for initialization
	void Start () {
        type = GameState.StateType.Game;
        stateName = "Level1";
        base.Start();
	}
	
    void Update()
    {
        if (!GameGlobals.Instance.playerAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameGlobals.Instance.SetDefaults();
                GameGlobals.Instance.stateManager.ChangeState(StateType.Game, "Level1");
            }
        }
    }
	
}
