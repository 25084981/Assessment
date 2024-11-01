using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GhostScript : MonoBehaviour
{
    public Color c;
    public GameObject target; // player
    public NavMeshAgent agent; // ghosts
    public SaveScore myscore; // to display leaderboard if the player collides with ghost
    public AudioClip bomb; // audio clip when the player collides with the ghost
    private AudioSource audioSource;

    public bool isAway;
    private int timeLeft = 15;
    private bool timeStart = false;
    public int multiplyBy = 5;

    public GameObject Lost;

    void Start()
    {
        GetComponent<Renderer>().material.color = c;
        isAway = true;
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (isAway)
        {
            agent.destination = target.transform.position;
        }
        else
        {
            RunFrom();
        }

        if (!isAway && !timeStart)
        {
            timeStart = true;
            StartCoroutine(LoseTime());
        }

        if (timeLeft <= 0)
        {
            isAway = true;
            GetComponent<Renderer>().material.color = c;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isAway)
            {
                HandlePlayerCollision();
            }
            else
            {
                Destroy(agent.gameObject);
            }
        }
    }

    private void HandlePlayerCollision()
    {
        Debug.Log("Player collided with ghost");
        myscore.alive = false; // calls the stuff from savescore
        Time.timeScale = 0;
        Lost.SetActive(true);
        PlayCollisionSound();
    }

    private void PlayCollisionSound()
    {
        audioSource.clip = bomb; // play audio upon collision
        audioSource.Play();
    }

    public void RunFrom()
    {
        agent.transform.rotation = Quaternion.LookRotation(agent.transform.position - target.transform.position);
        Vector3 runTo = transform.position + transform.forward * multiplyBy;

        NavMeshHit hit;
        NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetNavMeshLayerFromName("Default"));
        agent.SetDestination(hit.position);
    }

    private IEnumerator LoseTime()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
