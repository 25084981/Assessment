using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void StartGame()
    {
        LoadScene("Game4");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credit()
    {
        LoadScene("Producer");
    }

    public void Rule()
    {
        LoadScene("Rule");
    }

    public void Back()
    {
        LoadScene("Menu");
    }

    public void Score()
    {
        LoadScene("Score");
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
