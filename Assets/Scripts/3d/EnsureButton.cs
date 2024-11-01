using UnityEngine;
using UnityEngine.UI;

public class EnsureButton : MonoBehaviour
{
    public GameObject FunctionButton;
    public GameObject ScoreButton;
    public GameManager GameManager;
    public Text UserName;
    public Text Score;

    public void EnableFuncion()
    {
        if (IsUserNameValid())
        {
            RecordScore();
            ToggleButtons();
        }
    }

    private bool IsUserNameValid()
    {
        return !string.IsNullOrEmpty(UserName.text);
    }

    private void RecordScore()
    {
        string scoreValue = Score.text.Substring(0, Score.text.Length - 1);
        GameManager.Record(UserName.text, scoreValue);
    }

    private void ToggleButtons()
    {
        FunctionButton.SetActive(true);
        ScoreButton.SetActive(false);
    }
}
