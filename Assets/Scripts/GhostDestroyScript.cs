using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostDestroyScript : MonoBehaviour
{
    public GhostScript g1;
    public GhostScript g2;
    public GhostScript g3;
    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;
    public GameObject myfruit;
    public Color mycolor;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeGhostColors(mycolor);
            SetGhostsActiveState(false);
            Destroy(myfruit);
        }
    }

    private void ChangeGhostColors(Color color)
    {
        ghost1.GetComponent<Renderer>().material.color = color;
        ghost2.GetComponent<Renderer>().material.color = color;
        ghost3.GetComponent<Renderer>().material.color = color;
    }

    private void SetGhostsActiveState(bool state)
    {
        g1.isAway = state;
        g2.isAway = state;
        g3.isAway = state;
    }
}
