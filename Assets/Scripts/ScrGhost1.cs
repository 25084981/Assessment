using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrGhost1 : MonoBehaviour {

    public int navItr;
    public GameObject[] navArr;
    public Transform target;

    public GameObject pacman;

    public bool isEdible;
    public float isEdibleTimer;

    private Animator animator;

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();

        isEdible = pacman.GetComponent<ScrPacMan>().GhostEdible;
        isEdibleTimer = pacman.GetComponent<ScrPacMan>().GhostEdibleTimer;


        navItr = 0;
        navArr = new GameObject[18];
        navArr[0] = GameObject.Find("NavPoint");
        navArr[1] = GameObject.Find("NavPoint (1)");
        navArr[2] = GameObject.Find("NavPoint (2)");
        navArr[3] = GameObject.Find("NavPoint (5)");
        navArr[4] = GameObject.Find("NavPoint (9)");
        navArr[5] = GameObject.Find("NavPoint (8)");
        navArr[6] = GameObject.Find("NavPoint (10)");
        navArr[7] = GameObject.Find("NavPoint (11)");
        navArr[8] = GameObject.Find("NavPoint (12)");
        navArr[9] = GameObject.Find("NavPoint (14)");
        navArr[10] = GameObject.Find("NavPoint (13)");
        navArr[11] = GameObject.Find("NavPoint (7)");
        navArr[12] = GameObject.Find("NavPoint (6)");
        navArr[13] = GameObject.Find("NavPoint (4)");
        navArr[14] = GameObject.Find("NavPoint");
        navArr[15] = GameObject.Find("NavPoint (1)");
        navArr[16] = GameObject.Find("NavPoint (3)");
        navArr[17] = GameObject.Find("NavPoint (4)");

        pacman = GameObject.Find("PacMan");

    }
	
	// Update is called once per frame
	void Update () {

        target = navArr[navItr].transform;
        transform.position = Vector2.MoveTowards(transform.position, target.position, 1 * Time.deltaTime);

        if (transform.position == target.position) {
            navItr++;
            if (navItr > 17) {
                navItr = 0;
            }
        }

        //edibleness
        isEdible = pacman.GetComponent<ScrPacMan>().GhostEdible;
        isEdibleTimer = pacman.GetComponent<ScrPacMan>().GhostEdibleTimer;

        if (isEdible == true)
        {
            animator.SetTrigger("IsEdible");
        }
        else if (isEdible == false) {
            animator.SetTrigger("IsNotEdible");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (isEdible == true)
            {
                animator.SetTrigger("Ate");
            }
        }
    }
}
