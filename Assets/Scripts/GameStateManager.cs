using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

        public GameObject gameStateObj;

        private GameState.StateType nextState;
        private bool loading;
        private string sceneToLoad = "";

        private void Awake()
        {
            DontDestroyOnLoad(GameObject.Find("PersistentObjects"));

            GameObject obj = GameObject.Find("DevModeCheck");
            if(null != obj)
            {
                Debug.Log("Found DMC, entering dev mode");
                DevModeCheck scene = obj.GetComponent<DevModeCheck>();
                sceneToLoad = scene.sceneName;
                Destroy(obj);
            }
        }

        private void Start()
        {
            if(sceneToLoad != "")
            {
                switch (sceneToLoad)
                {
                    case "MainMenu":
                        ChangeState(GameState.StateType.MainMenu, sceneToLoad);
                        sceneToLoad = "";
                        break;

                    case "Level1":
                        ChangeState(GameState.StateType.Game, sceneToLoad);
                        sceneToLoad = "";
                        break;
                }
            }
            else
            {
                DontDestroyOnLoad(gameStateObj);
                SetState(GameState.StateType.SplashScreen);
            }
        }

	    public void ChangeState(GameState.StateType state, string levelName="")
        {
            Destroy(gameStateObj);

            if(levelName != "")
            {
                loading = true;
                nextState = state;
                SceneManager.LoadScene(levelName);
            }else
            {
                SetState(state);
            }
        }

        private void SetState(GameState.StateType state)
        {
            gameStateObj = new GameObject();
            DontDestroyOnLoad(gameStateObj);

            switch (state)
            {
                case GameState.StateType.SplashScreen:
                    gameStateObj.AddComponent<SplashSceen_In>();
                    gameStateObj.name = "SplashScreenState";
                    break;

                case GameState.StateType.MainMenu:
                    gameStateObj.AddComponent<MainMenu_In>();
                    gameStateObj.name = "MainMenuState";
                    break;

                case GameState.StateType.Game:
                    gameStateObj.AddComponent<Game_In>();
                    gameStateObj.name = "GameState";
                    break;            
            }

            nextState = GameState.StateType.Null;
            loading = false;
        }

        void OnEnable()
        {
            SceneManager.sceneLoaded += LevelWasLoaded;
        }

        public void LevelWasLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (loading)
            {
                SetState(nextState);
            }
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= LevelWasLoaded;
        }
}
