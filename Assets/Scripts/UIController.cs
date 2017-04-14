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

    // Use this for initialization
    void Awake () {
        _coinsText.text = GameGlobals.Instance.coinsCollected.ToString();
        _scoreText.text = "Score: " + GameGlobals.Instance.score;

    }
	
	// Update is called once per frame
	void Update () {

        _coinsText.text = GameGlobals.Instance.coinsCollected.ToString();
        _scoreText.text = "Score: " + GameGlobals.Instance.score;

        if (!GameGlobals.Instance.playerAlive)
        {
            
            _continueText.text = "Coins: " + _coinsText.text + "\n" + _scoreText.text + "\n" + "Press Space to continue!";
            _continueText.enabled = true;
        }

	}
}
