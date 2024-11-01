using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrGhost3 : MonoBehaviour {

    public int navItr;
    public GameObject[] navArr;
    public Transform target;

    public GameObject pacman;

    public bool isEdible;
    public float isEdibleTimer;

    private Animator animator;

    // Use this for initialization
    void Start () {
        
        navItr = 0;
        navArr = new GameObject[31];
        navArr[0] = GameObject.Find("NavPoint (27)");
        navArr[1] = GameObject.Find("NavPoint (51)");
        navArr[2] = GameObject.Find("NavPoint (52)");
        navArr[3] = GameObject.Find("NavPoint (53)");
        navArr[4] = GameObject.Find("NavPoint (54)");
        navArr[5] = GameObject.Find("NavPoint (55)");
        navArr[6] = GameObject.Find("NavPoint (63)");
        navArr[7] = GameObject.Find("NavPoint (62)");
        navArr[8] = GameObject.Find("NavPoint (61)");
        navArr[9] = GameObject.Find("NavPoint (60)");
        navArr[10] = GameObject.Find("NavPoint (59)");
        navArr[11] = GameObject.Find("NavPoint (58)");
        navArr[12] = GameObject.Find("NavPoint (57)");
        navArr[13] = GameObject.Find("NavPoint (51)");
        navArr[14] = GameObject.Find("NavPoint (50)");
        navArr[15] = GameObject.Find("NavPoint (49)");
        navArr[16] = GameObject.Find("NavPoint (48)");
        navArr[17] = GameObject.Find("NavPoint (47)");
        navArr[18] = GameObject.Find("NavPoint (46)");
        navArr[19] = GameObject.Find("NavPoint (32)");
        navArr[20] = GameObject.Find("NavPoint (31)");
        navArr[21] = GameObject.Find("NavPoint (30)");
        navArr[22] = GameObject.Find("NavPoint (28)");
        navArr[23] = GameObject.Find("NavPoint (29)");
        navArr[24] = GameObject.Find("NavPoint (15)");
        navArr[25] = GameObject.Find("NavPoint (11)");
        navArr[26] = GameObject.Find("NavPoint (12)");
        navArr[27] = GameObject.Find("NavPoint (14)");
        navArr[28] = GameObject.Find("NavPoint (31)");
        navArr[29] = GameObject.Find("NavPoint (30)");
        navArr[30] = GameObject.Find("NavPoint (28)");
        
        pacman = GameObject.Find("PacMan");

        animator = GetComponent<Animator>();

        isEdible = pacman.GetComponent<ScrPacMan>().GhostEdible;
        isEdibleTimer = pacman.GetComponent<ScrPacMan>().GhostEdibleTimer;
    }
	
	// Update is called once per frame
	void Update () {

        target = navArr[navItr].transform;
        transform.position = Vector2.MoveTowards(transform.position, target.position, 1 * Time.deltaTime);

        if (transform.position == target.position) {
            navItr++;
            if (navItr > 30) {
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
