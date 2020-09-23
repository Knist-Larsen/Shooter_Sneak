using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Runtime.CompilerServices;

public class enemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject nose;
    public List<Vector3> checkpoints;

    Vector3 enemyPos;
    public float synsfelt;

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
        enemyPos = nose.transform.position;

        if (/*Vector3.Distance(player.transform.position, this.transform.position)*/ DistanceToPlayer(player.transform.position,enemyPos,synsfelt) > 5f)
        {
            if (ShouldSetDestination())
            {
                agent.SetDestination(pathPoints.Dequeue());
            }
            if (pathPoints.Count == 0)
            {
                SetPoints(checkpoints);
            }
        }
        else
        {
            pathPoints.Clear();
            // Sets the navigation for the enemy
            agent.SetDestination(player.transform.position);
        }
    }

    static float DistanceToPlayer(Vector3 player, Vector3 enemy, float synsfelt)
    {
        enemy.z += 0.5f * synsfelt;

        return Vector3.Distance(player, enemy);
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
