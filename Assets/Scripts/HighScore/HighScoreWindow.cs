using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreWindow : MonoBehaviour {

    private VerticalLayoutGroup _verticalLG;

    public HighScoreItem _scoreItemPrefab;

    public void Init()
    {
        _verticalLG = GetComponentInChildren<VerticalLayoutGroup>(true);

        var highScores = GameGlobals.Instance.highScoreManager.HighScores;

        foreach(var score in highScores)
        {
            if(score != null)
            {
                var scoreItem = Instantiate(_scoreItemPrefab, _verticalLG.transform, false);
                scoreItem.Init(score);
            }

        }
    }
    public void OpenWindow()
    {

        gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
