using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGlobals : MonoBehaviour {

    private static GameGlobals _instance;

    public GameStateManager stateManager;

    public bool playerAlive;
    public int score;
    public int coinsCollected;

    public static GameGlobals Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject GlobalsObj = new GameObject(typeof(GameGlobals).Name);
                _instance = GlobalsObj.AddComponent<GameGlobals>();
            }

            return _instance;
        }
    }
	// Use this for initialization
	void Awake () {
		if(_instance == null)
        {
            _instance = this;
        }

        if(_instance == this)
        {
            Init();
        }
        else
        {
            Destroy(this);
        }
	}

    private void Init()
    {
        stateManager = FindObjectOfType<GameStateManager>();
        SetDefaults();
 
    }

    public void SetDefaults()
    {
        playerAlive = true;
        score = 0;
        coinsCollected = 0;
    }

}
