using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrGhost2 : MonoBehaviour {

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
        navArr = new GameObject[25];
        navArr[0] = GameObject.Find("NavPoint (20)");
        navArr[1] = GameObject.Find("NavPoint (19)");
        navArr[2] = GameObject.Find("NavPoint (5)");
        navArr[3] = GameObject.Find("NavPoint (9)");
        navArr[4] = GameObject.Find("NavPoint (8)");
        navArr[5] = GameObject.Find("NavPoint (10)");
        navArr[6] = GameObject.Find("NavPoint (11)");
        navArr[7] = GameObject.Find("NavPoint (15)");
        navArr[8] = GameObject.Find("NavPoint (16)");
        navArr[9] = GameObject.Find("NavPoint (17)");
        navArr[10] = GameObject.Find("NavPoint (18)");
        navArr[11] = GameObject.Find("NavPoint (26)");
        navArr[12] = GameObject.Find("NavPoint (21)");
        navArr[13] = GameObject.Find("NavPoint (22)");
        navArr[14] = GameObject.Find("NavPoint (23)");
        navArr[15] = GameObject.Find("NavPoint (24)");
        navArr[16] = GameObject.Find("NavPoint (25)");
        navArr[17] = GameObject.Find("NavPoint (27)");
        navArr[18] = GameObject.Find("NavPoint (28)");
        navArr[19] = GameObject.Find("NavPoint (29)");
        navArr[20] = GameObject.Find("NavPoint (15)");
        navArr[21] = GameObject.Find("NavPoint (16)");
        navArr[22] = GameObject.Find("NavPoint (17)");
        navArr[23] = GameObject.Find("NavPoint (18)");
        navArr[24] = GameObject.Find("NavPoint (19)");

        pacman = GameObject.Find("PacMan");

    }
	
	// Update is called once per frame
	void Update () {

        target = navArr[navItr].transform;
        transform.position = Vector2.MoveTowards(transform.position, target.position, 1 * Time.deltaTime);

        if (transform.position == target.position) {
            navItr++;
            if (navItr > 24) {
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
