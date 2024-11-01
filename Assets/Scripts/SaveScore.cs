using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour
{
    public InputField inputText;
    public Text finalScore;
    public GameObject entername;
    public GameObject secScore;
    public bool alive = true;
    public GameObject Win;

    void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        inputText.DeactivateInputField();
        inputText.characterLimit = 3;
        entername.SetActive(false);
        secScore.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        finalScore.text = PlayerPrefs.GetString("PelletScore");
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (PlayerPrefs.GetString("PelletScore") == "Score: 5400" || !alive)
        {
            Time.timeScale = 0;
            Win.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    private bool IsHighScore(int score1, int score2)
    {
        return score1 > score2;
    }

    public void LeaderScorers()
    {
        string[] scores = finalScore.text.Split(' ');

        if (!PlayerPrefs.HasKey("player0"))
        {
            PlayerPrefs.SetString("player0", inputText.text);
            PlayerPrefs.SetString("score0", scores[1]);
        }
        else if (!PlayerPrefs.HasKey("player1"))
        {
            UpdatePlayerScores(scores, 0, 1);
        }
        else if (!PlayerPrefs.HasKey("player2"))
        {
            UpdatePlayerScores(scores, 1, 2);
        }
        else
        {
            UpdatePlayerScores(scores, 2, 3);
        }

        Time.timeScale = 1;
    }

    private void UpdatePlayerScores(string[] scores, int currentPlayerIndex, int nextPlayerIndex)
    {
        string score0 = PlayerPrefs.GetString("score0");
        string score1 = PlayerPrefs.GetString("score1");

        if (IsHighScore(int.Parse(scores[1]), int.Parse(score0)))
        {
            PlayerPrefs.SetString("player" + nextPlayerIndex, PlayerPrefs.GetString("player" + (nextPlayerIndex - 1)));
            PlayerPrefs.SetString("score" + nextPlayerIndex, PlayerPrefs.GetString("score" + (nextPlayerIndex - 1)));
            PlayerPrefs.SetString("player" + currentPlayerIndex, inputText.text);
            PlayerPrefs.SetString("score" + currentPlayerIndex, scores[1]);
        }
        else if (IsHighScore(int.Parse(scores[1]), int.Parse(score1)))
        {
            PlayerPrefs.SetString("player" + nextPlayerIndex, inputText.text);
            PlayerPrefs.SetString("score" + nextPlayerIndex, scores[1]);
        }
        else
        {
            PlayerPrefs.SetString("player" + nextPlayerIndex, inputText.text);
            PlayerPrefs.SetString("score" + nextPlayerIndex, scores[1]);
        }
    }
}
