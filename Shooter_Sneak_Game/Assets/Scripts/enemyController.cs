using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class enemyController : MonoBehaviour
{
    public GameObject player;
    public Queue<Vector3> checkpoints;

    bool playerSeen = false;

    float coolDownTime = 5f;
    NavMeshAgent agent;
    Queue<Vector3> pathPoints = new Queue<Vector3>();

    // Start is called before the first frame update
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void SetPoints(IEnumerable<Vector3> points)
    {
        pathPoints = new Queue<Vector3>(points);
    }

    // Update is called once per frame
    public void Update()
    {
        

        if (playerSeen == false)
        {
            if (ShouldSetDestination())
            {
                agent.SetDestination(pathPoints.Dequeue());
            }
            if (pathPoints.Count == 0)
            {
                pathPoints = checkpoints;
            }
        }
        if (playerSeen == true)
        {
            // Sets the navigation for the enemy
            agent.destination = player.transform.position;
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        playerSeen = true;
    }
    private void OnTriggerExit(Collider other)
    {
        playerSeen = false;
    }

    private bool ShouldSetDestination()
    {
        if (pathPoints.Count == 0)
        {
            return false;
        }
        if (agent.hasPath == false || agent.remainingDistance < 0.5f)
        {
            return true;
        }
        return false;
    }
}
