using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrPacMan : MonoBehaviour
{

    public int score;
    public int pelletScore = 1;
    public int GhostEdibleScore = 4;
    public int lives;

    public int ghostsAte;
    public int HP;
    public bool GhostEdible;
    public float GhostEdibleTimer;

    private GameObject NavPoints;
    public GameObject Lost;

    private float speed = 1.0f;
    private Animator animator;

    void Start()
    {
        NavPoints = GameObject.Find("NavPoints");
        animator = GetComponent<Animator>();
        ghostsAte = 1;
        lives = 3;
    }

    void Update()
    {
        // 处理游戏结束
        if (lives <= 0)
        {
            Lost.SetActive(true);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Debug.Log("Reloaded!");
            return; // 避免继续执行
        }

        // 处理输入
        HandleMovementInput();

        // 更新移动
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        // 检查死亡状态
        if (HP <= 0)
        {
            animator.SetTrigger("Died");
        }

        // 处理可食用状态
        UpdateGhostEdibility();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 9)
        {
            Physics2D.IgnoreCollision(coll.collider, GetComponent<Collider2D>());
        }

        HandleCollision(coll);
    }

    private void HandleMovementInput()
    {
        if (Input.GetKey("up")) animator.SetTrigger("MoveUp");
        if (Input.GetKey("down")) animator.SetTrigger("MoveDown");
        if (Input.GetKey("left")) animator.SetTrigger("MoveLeft");
        if (Input.GetKey("right")) animator.SetTrigger("MoveRight");
    }

    private void UpdateGhostEdibility()
    {
        if (GhostEdible)
        {
            speed = 2;
            GhostEdibleTimer -= Time.deltaTime;
            if (GhostEdibleTimer <= 0)
            {
                GhostEdible = false;
                speed = 1;
                GhostEdibleTimer = 5;
            }
        }
    }

    private void HandleCollision(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ghost")
        {
            if (!GhostEdible)
            {
                lives--;
                transform.position = new Vector3(0f, -0.8f, 0f); // respawn
            }
            else
            {
                score += GhostEdibleScore * ghostsAte;
                ghostsAte++;
            }
        }

        if (coll.gameObject.tag == "PowerUpDot")
        {
            GhostEdible = true;
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "pellet")
        {
            score += pelletScore;
            Destroy(coll.gameObject);
        }
    }
}
