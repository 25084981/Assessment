using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : MonoBehaviour
{
    public static int pelletCount = 0;

    // Use this for initialization
    void Start()
    {
        InitializeScore();
    }

    private void InitializeScore()
    {
        PlayerPrefs.SetString("PelletScore", "Score: ");
        pelletCount = 0;
    }

    public void OnDestroy()
    {
        IncrementPelletCount();
    }

    private void IncrementPelletCount()
    {
        pelletCount++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        PlayerPrefs.SetString("PelletScore", "Score: " + pelletCount * 100);
    }
}
