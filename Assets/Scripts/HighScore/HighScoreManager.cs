using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager {

    private SaveLoad<HighScoreData> _saveLoad;

    private HighScoreData[] _highScores = new HighScoreData[5];

    public HighScoreData[] HighScores
    {
        get { return _highScores; }
    }
	
    public HighScoreManager(SaveLoad<HighScoreData> saveLoad)
    {
        _saveLoad = saveLoad;

        _highScores = GetAllHighScores();
    }

    public void Save(HighScoreData data, string saveFileName)
    {
        _saveLoad.Save(data, saveFileName);
    }

    public HighScoreData Load(string fileName)
    {
        return _saveLoad.Load(fileName);
    }

    public void RearrangeHighScore(HighScoreData newData)
    {
        var dataToHandle = newData;

        for (int i = 0; i < _highScores.Length; i++)
        {

            if(_highScores[i] == null)
            {
                dataToHandle.placement = i + 1;
                _highScores[i] = dataToHandle;
                break;

            }else if(dataToHandle.score > _highScores[i].score)
            {

                for(int j = i; j < _highScores.Length; j++)
                {
                    if (j < 4)
                    {
                        dataToHandle.placement = j + 1;
                        var temp = _highScores[j];
                        _highScores[j] = dataToHandle;

                        dataToHandle = temp;
                    }else if(j == 4)
                    {
                        dataToHandle.placement = j + 1;
                        _highScores[j] = dataToHandle;
                    }

                    if(dataToHandle == null)
                    {
                        break;
                    }
                }

                break;
           
            }

        }

        foreach(HighScoreData data in _highScores)
        {
            if(data != null)
            Save(data, "HighScore" + data.placement);
        }
    }

    public bool CheckBoards(int score)
    {
        bool result = false;

        foreach(HighScoreData data in _highScores)
        {
            if(data == null || data.score < score)
            {
                result = true;
            }
        }

        return result;
    }

    public HighScoreData[] GetAllHighScores()
    {
        HighScoreData[] result = new HighScoreData[5];

        for(int i = 0; i < _highScores.Length; i++)
        {
            result[i] = Load("HighScore" + (i+1));
        }

        return result;
    }
}
