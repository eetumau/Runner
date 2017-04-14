using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSceen_In : GameState {

    private float _eventTime;


    // Use this for initialization
    protected override void Start()
    {
        type = StateType.SplashScreen;
        stateName = "Splash Screen";
        base.Start();
        _eventTime = Time.time;
    }
	
	// Update is called once per frame
	protected override void Update () {
		if(Time.time - _eventTime > 1)
        {
            GameGlobals.Instance.stateManager.ChangeState(StateType.MainMenu, "MainMenu");
        }
	}
    
}
