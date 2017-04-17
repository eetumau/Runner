using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreItem : MonoBehaviour {

    private Text _text;

	public void Init(HighScoreData data)
    {
        _text = GetComponent<Text>();

        _text.text = string.Format("{0}. {1} Score: {2} Coins: {3}", data.placement, data.name, data.score, data.coins);
    }
}
