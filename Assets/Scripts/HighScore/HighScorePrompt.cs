using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePrompt : MonoBehaviour {

    private HighScoreData _scoreData;
    
    private InputField _inputField;

    private UIController _uiController;

    private void Awake()
    {
        _inputField = GetComponentInChildren<InputField>();
    }
	public void Open(UIController controller)
    {
        _uiController = controller;
        gameObject.SetActive(true);
    }

    public void Save()
    {

        _scoreData = new HighScoreData()
        {
            name = _inputField.GetComponentInChildren<Text>().text,
            score = GameGlobals.Instance.score,
            coins = GameGlobals.Instance.coinsCollected
        };

        GameGlobals.Instance.highScoreManager.RearrangeHighScore(_scoreData);

        _uiController.highScoreSaved = true;
        gameObject.SetActive(false);
    }

}
