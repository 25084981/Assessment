using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardScript : MonoBehaviour
{
    public Text player0;
    public Text player1;
    public Text player2;
    public Text score0;
    public Text score1;
    public Text score2;

    void Start()
    {
        LoadPlayerData("player0", player0, score0);
        LoadPlayerData("player1", player1, score1);
        LoadPlayerData("player2", player2, score2);
    }

    private void LoadPlayerData(string playerKey, Text playerText, Text scoreText)
    {
        if (PlayerPrefs.HasKey(playerKey))
        {
            playerText.text = PlayerPrefs.GetString(playerKey);
            scoreText.text = PlayerPrefs.GetString("score" + playerKey[^1]); // 获取对应分数
        }
    }

    void Update()
    {
        // 可选：如果需要粒子效果或其他更新逻辑，可以在这里添加
    }
}
