using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] checkpoints;

    bool playerSeen = false;

    float coolDownTime = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        if (playerSeen == false)
        {
            //int i = 0;
            /*
            for (int i = 0; i < checkpoints.Length;)
            {
                agent.destination = checkpoints[i].transform.position;
                if (agent.destination == checkpoints[i].transform.position)
                {
                    i++;
                }
            }
            */
            /*
            while (i < checkpoints.Length)
            {
                agent.destination = checkpoints[i].transform.position;
                
                if (agent.destination == checkpoints[i].transform.position)
                {
                    i++;
                }
            }*/
        }
        if (playerSeen == true)
        {
            // Sets the navigation for the enemy
            agent.destination = player.transform.position;
        }
    }

    private void OnTriggerEnter(Collider player)
    {/*
        if (playerSeen == false)
        {
            playerSeen = true;
        }

        float time = 0;
        while (time < coolDownTime)
        {
            time += Time.deltaTime;
        }
        playerSeen = false; */

        playerSeen = true;
    }
    private void OnTriggerExit(Collider other)
    {
        playerSeen = false;
    }
}
