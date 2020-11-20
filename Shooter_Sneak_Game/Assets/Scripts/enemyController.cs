using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

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

    // Bliver kaldt 1 gang per frame
    public void Update()
    {
        
        enemyPos = transform.position;
        Vector3 startRay = enemyPos;
        Vector3 endRayPlayer = player.transform.position;
        ray = new Ray(startRay, endRayPlayer - startRay);
        if (CanMoveToPlayer(startRay, endRayPlayer - startRay))
        {
            pathPoints.Clear();
            // Setter navigationen for fjenden
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

    // Bliver kaldt 60 gange i sekundet
    void FixedUpdate()
    {
        // Tjekker om spilleren er blevet set, og der er gået 1 sekund
        if (playerSeen == true && time >= 1)
        {
            // sætter en kugle ind i scenen, for enden af geværet i spillerens retning
            var clone = Instantiate(bullet, nose.transform.position, Quaternion.LookRotation(ray.direction));
            Debug.Log("Playerseen");
            clone.name = "Bullet";
            clone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000);
            clone.transform.localScale = bulletScale;
            // Sætter tiden tilbage til 0
            time = 0;
        }
        // Tilføjer den tid der er gået siden sidste opdatering til den samlede tid
        time += Time.deltaTime;

    }

    // Tjekker om Fjenden skal starte på en ny rute
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

    // Tjekker om Fjenden kan se spilleren
    bool CanMoveToPlayer(Vector3 startRay, Vector3 endRay)
    {
        // Tjekker om der er en lige linje til spilleren, & at spilleren er inden for rækkevidde
        if (Physics.Raycast(startRay, endRay, out hit, synsfelt))
        {
            // Tjekker om det er spilleren der bliver set
            if (hit.collider.gameObject.tag == "Player")
            {
                return true;
            }
            // Andgiver hvad der blev ramt, når det ikke var spilleren
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
