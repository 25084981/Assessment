using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;
    public Text remainDot;
    public AudioManager audioManager;

    void OnTriggerEnter(Collider other)
    {
        HandleCollision(other);
    }

    void Update()
    {
        CheckFallOff();
    }

    private void HandleCollision(Collider other)
    {
        switch (other.tag)
        {
            case "Dot":
                CollectDot(other);
                break;
            case "Ghost":
                gameManager.Die();
                break;
        }
    }

    private void CollectDot(Collider dot)
    {
        Destroy(dot.gameObject);
        audioManager.eatDot();
        UpdateRemainingDots();
    }

    private void UpdateRemainingDots()
    {
        int remaining = Convert.ToInt32(remainDot.text);
        remaining--;
        remainDot.text = remaining.ToString();
        if (remaining == 0)
        {
            gameManager.Win();
        }
    }

    private void CheckFallOff()
    {
        if (transform.position.y < -1)
        {
            gameManager.Die();
        }
    }
}
