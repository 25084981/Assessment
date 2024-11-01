using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RefreshScores();
    }

    void Update()
    {
        RefreshScores();
    }

    private void RefreshScores()
    {
        for (int i = 1; i <= 5; i++)
        {
            UpdateScoreDisplay(i);
        }
    }

    private void UpdateScoreDisplay(int index)
    {
        GameObject.Find("id" + index).GetComponent<Text>().text = index.ToString();
        GameObject.Find("playername" + index).GetComponent<Text>().text = PlayerPrefs.GetString("Name" + index, "暂无");

        string timeText;
        int scoreTime = PlayerPrefs.GetInt("time" + index, -1);
        if (scoreTime != -1)
        {
            timeText = scoreTime.ToString() + "秒";
        }
        else
        {
            timeText = "暂无";
        }

        GameObject.Find("time" + index).GetComponent<Text>().text = timeText;
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        RefreshScores();
    }
}
