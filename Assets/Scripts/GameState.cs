using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public enum StateType
    {
        Null = 0,
        SplashScreen = 1,
        MainMenu = 2,
        Game = 3
    }

    protected string stateName = "";
    protected StateType type;

    protected GameStateManager stateManager;

	// Use this for initialization
	protected virtual void Start () {
        Debug.Log(stateName);
        stateManager = GameGlobals.Instance.stateManager;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}

    protected virtual void OnDisable()
    {
        Debug.Log("Exiting state");
    }
}
