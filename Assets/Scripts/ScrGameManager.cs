using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrGameManager : MonoBehaviour
{
    public GameObject Win;

    void Start()
    {
        // 可以在这里进行初始化操作
    }

    void Update()
    {
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (GameObject.FindWithTag("pellet") == null)
        {
            ShowWinScreen();
        }
    }

    private void ShowWinScreen()
    {
        Win.SetActive(true);
       
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
