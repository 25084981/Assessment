using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public long startTime = 5;
    public Transform player;
    public GameObject ghost_0;
    public float moveTime_0;
    public GameObject ghost_1;
    public float moveTime_1;
    public GameObject ghost_2;
    public float moveTime_2;
    public GameObject ghost_3;
    public float moveTime_3;

    private Transform[] ghostTransforms;
    private NavMeshAgent[] ghostNavAgents;

    private float loadTime;

    private void Sleep(NavMeshAgent g)
    {
        g.updatePosition = false;
        g.updateRotation = false;
    }

    private void Move(Transform t, NavMeshAgent g, Vector3 destination)
    {
        g.updatePosition = true;
        g.updateRotation = true;
        g.SetDestination(destination);
        t.LookAt(destination);
    }

    private void Start()
    {
        loadTime = Time.time;

        ghostTransforms = new Transform[] {
            ghost_0.GetComponent<Transform>(),
            ghost_1.GetComponent<Transform>(),
            ghost_2.GetComponent<Transform>(),
            ghost_3.GetComponent<Transform>()
        };

        ghostNavAgents = new NavMeshAgent[] {
            ghost_0.GetComponent<NavMeshAgent>(),
            ghost_1.GetComponent<NavMeshAgent>(),
            ghost_2.GetComponent<NavMeshAgent>(),
            ghost_3.GetComponent<NavMeshAgent>()
        };

        foreach (var g in ghostNavAgents)
        {
            Sleep(g);
        }
    }

    void FixedUpdate()
    {
        if (Time.time - loadTime < startTime) return;

        if (Time.time - loadTime > moveTime_0)
        {
            Move(ghostTransforms[0], ghostNavAgents[0], player.position);
        }
        if (Time.time - loadTime > moveTime_1)
        {
            Move(ghostTransforms[1], ghostNavAgents[1], player.position);
        }
        if (Time.time - loadTime > moveTime_2)
        {
            Move(ghostTransforms[2], ghostNavAgents[2], player.position);
        }
        if (Time.time - loadTime > moveTime_3)
        {
            Move(ghostTransforms[3], ghostNavAgents[3], player.position);
        }
    }
}
