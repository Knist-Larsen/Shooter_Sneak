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

    public static Vector3 enemyPos;
    public float synsfelt;

    NavMeshAgent agent;
    Queue<Vector3> pathPoints = new Queue<Vector3>();

    public GameObject bullet;
    public Vector3 bulletScale = new Vector3(1,1,1);
    float time = 0;

    public bool playerSeen;

    RaycastHit hit;
    Ray ray;

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
        
        enemyPos = transform.position;
        Vector3 startRay = enemyPos;
        Vector3 endRayPlayer = player.transform.position;
        ray = new Ray(startRay, endRayPlayer - startRay);
        if (CanMoveToPlayer(startRay, endRayPlayer - startRay))
        {
            pathPoints.Clear();
            // Sets the navigation for the enemy
            agent.SetDestination(player.transform.position);
            Debug.DrawRay(startRay, agent.destination - startRay, Color.red);
            playerSeen = true;
        }
        else
        {
            if (ShouldSetDestination())
            {
                agent.SetDestination(pathPoints.Dequeue());
            }
            if (pathPoints.Count == 0)
            {
                SetPoints(checkpoints);
            }
            Debug.DrawRay(startRay, agent.destination - startRay, Color.green);
            playerSeen = false;
        }
    }
    void FixedUpdate()
    {
        if (playerSeen == true && time >= 1)
        {
            var clone = Instantiate(bullet, nose.transform.position, Quaternion.LookRotation(ray.direction));
            Debug.Log("Playerseen");
            clone.name = "Bullet";
            clone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000);
            clone.transform.localScale = bulletScale;
            time = 0;
        }
        time += Time.deltaTime;

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
    bool CanMoveToPlayer(Vector3 startRay, Vector3 endRay)
    {
        if (Physics.Raycast(startRay, endRay, out hit, synsfelt))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                return true;
            }
            else
            {
                Debug.Log("I hit " + hit.collider.gameObject.name);
                Debug.DrawRay(startRay, endRay, Color.yellow);
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
