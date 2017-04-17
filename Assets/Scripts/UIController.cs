using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField]
    private Text _coinsText;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _continueText;
    [SerializeField]
    private GameObject _gameOverWindow;
    [SerializeField]
    private HighScorePrompt _highScoreWindow;

    public bool highScoreSaved = false;

    // Use this for initialization
    void Awake () {
        _coinsText.text = GameGlobals.Instance.coinsCollected.ToString();
        _scoreText.text = "Score: " + GameGlobals.Instance.score;
        _highScoreWindow = GetComponentInChildren<HighScorePrompt>(true);

    }
	
	// Update is called once per frame
	void Update () {

        _coinsText.text = GameGlobals.Instance.coinsCollected.ToString();
        _scoreText.text = "Score: " + GameGlobals.Instance.score;

        if (!GameGlobals.Instance.playerAlive)
        {
            if (GameGlobals.Instance.highScoreManager.CheckBoards(GameGlobals.Instance.score) && !highScoreSaved)
            {
                _highScoreWindow.Open(this);
            }
            else
            {
                highScoreSaved = true;
                _gameOverWindow.SetActive(true);
                _continueText.text = "Coins: " + _coinsText.text + "\n" + _scoreText.text + "\n" + "Press Space to restart or \n Esc to exit to menu!";
                _continueText.enabled = true;
            }
            

        }
	}


}
