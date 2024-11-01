using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseEvent : MonoBehaviour
{
    public GameManager GameManager;

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Back()
    {
        GameManager.BackToGame();
    }
}
