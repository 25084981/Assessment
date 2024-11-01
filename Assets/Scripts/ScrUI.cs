using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrUI : MonoBehaviour {

    public GameObject PacMan;

    public static int score;
    public static int lives;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }


    void Update()
    {
        text.text = "Score: " + score + "\n" + "Lives: " + lives;
        lives = PacMan.GetComponent<ScrPacMan>().lives;
        score = PacMan.GetComponent<ScrPacMan>().score;
    }
}
