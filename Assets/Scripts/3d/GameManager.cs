using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject Camera_Main;
    public GameObject Camera_Anim;
    public GameObject Count;
    public GameObject Num;
    public GameObject DieUI;
    public GameObject WinUI;
    public GameObject PauseMenu;
    public PlayerMovement Move;
    public AudioManager AudioManager;
    public Text TimeText;
    public Text WinTimeText;
    public Text LoseTimeText;

    private float timer = 0;
    private bool isStartTimer = false;
    private bool isShow = false;
    private bool isEnd = false;
    private string[] names = new string[5];
    private int[] times = new int[5];

    // 获胜
    public void Win()
    {
        if (!isEnd)
        {
            isStartTimer = false;
            WinTimeText.text = TimeText.text + "秒";
            AudioManager.win();
            EndGame(true);
        }
    }

    // 死亡
    public void Die()
    {
        if (!isEnd)
        {
            isStartTimer = false;
            LoseTimeText.text = TimeText.text + "s";
            AudioManager.death();
            EndGame(false);
        }
    }

    private void EndGame(bool isWin)
    {
        isEnd = true;
        Move.isEnd = true;
        if (isWin)
        {
            WinUI.SetActive(true);
        }
        else
        {
            DieUI.SetActive(true);
        }
        Num.SetActive(false);
    }

    // 开始倒计时
    public void StartGame()
    {
        AudioManager.CountPlay();
        Count.SetActive(true);
    }

    public void SwitchCount(GameObject oldCount, GameObject newCount)
    {
        oldCount.SetActive(false);
        if (newCount != null)
        {
            AudioManager.CountPlay();
            newCount.SetActive(true);
        }
        else
        {
            StartGameplay();
        }
    }

    private void StartGameplay()
    {
        AudioManager.GamePlay();
        Move.enabled = true;
        Num.SetActive(true);
        isStartTimer = true;
    }

    // 动画摄像机切换到游戏摄像机
    public void CameraStart()
    {
        Camera_Main.SetActive(true);
        Camera_Anim.SetActive(false);
        Invoke("StartGame", 2.5f);
    }

    void Update()
    {
        if (isStartTimer)
        {
            UpdateTimer();
            CheckPauseInput();
        }
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
        TimeText.text = ((int)timer).ToString();
    }

    private void CheckPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isShow)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        PauseMenu.SetActive(true);
        isShow = true;
        Time.timeScale = 0;
        AudioManager.PlayBreath();
    }

    public void BackToGame()
    {
        ResumeGame();
    }

    private void ResumeGame()
    {
        PauseMenu.SetActive(false);
        isShow = false;
        Time.timeScale = 1;
        AudioManager.GamePlay();
    }

    public void Record(string userName, string score)
    {
        GetRanks();
        int scoreValue = Int32.Parse(score);
        int loc = FindInsertLocation(scoreValue);

        if (loc >= 0)
        {
            ShiftRanks(loc);
            names[loc] = userName;
            times[loc] = scoreValue;
            StoreRanks();
        }
    }

    private int FindInsertLocation(int score)
    {
        for (int i = 0; i < 5; i++)
        {
            if (times[i] > score || times[i] == -1)
            {
                return i;
            }
        }
        return -1; // No insertion needed
    }

    private void ShiftRanks(int loc)
    {
        for (int i = 4; i > loc; i--)
        {
            names[i] = names[i - 1];
            times[i] = times[i - 1];
        }
    }

    public void GetRanks()
    {
        for (int i = 1; i <= 5; i++)
        {
            names[i - 1] = PlayerPrefs.GetString("Name" + i, "暂无");
            times[i - 1] = PlayerPrefs.GetInt("time" + i, -1);
        }
    }

    public void StoreRanks()
    {
        for (int i = 1; i <= 5; i++)
        {
            PlayerPrefs.SetString("Name" + i, names[i - 1]);
            PlayerPrefs.SetInt("time" + i, times[i - 1]);
        }
    }
}
