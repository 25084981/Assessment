using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartScene(string sceneName)
    {
        Time.timeScale = 1; // 确保时间流动
        LoadScene(sceneName);
    }

    private void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        QuitApplication();
    }

    private void QuitApplication()
    {
        Application.Quit();
        // 在编辑器中使用以下代码退出播放模式
        // #if UNITY_EDITOR
        // UnityEditor.EditorApplication.isPlaying = false; 
        // #endif
    }
}
