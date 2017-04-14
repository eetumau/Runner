using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevModeCheck : MonoBehaviour {

    public string sceneName;

	// Use this for initialization
	void Awake () {
        GameObject obj = GameObject.Find("PersistentObjects");

        if(null == obj)
        {
            Debug.Log("No persistent objects!");
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("SplashScreen");
        }
	}
	
}
