using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermediateMenuScript : MonoBehaviour
{
    public GameObject pause;

    void Start()
    {
        pause.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (!pause.activeInHierarchy)
        {
            PauseGame();
        }
        else
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }
}
