using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;


public enum Rooms
{
    Room1,
    Room2
}

public class enemyAiPartrol : MonoBehaviour

{
    // this code was from a tutorial however I am unable to locate that video
    GameObject Player;
    public List<PatrolPoint> Room1;
    public List<PatrolPoint> Room2;
    private List<List<PatrolPoint>> Rooms;
    private int targetIndex;
    public bool Dooropen = true;
    private string currentRoomTag;
    private int currentRoomIndex = 0;
    public GameObject destinationPrefab;
    public GameObject currentDestination;

    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    //patrol
    Vector3 desPoint;
    bool walkpointSet;
    [SerializeField] float range;

    //state change
    [SerializeField] float sightRange;
    bool playerInSight;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        Rooms = new List<List<PatrolPoint>>();
        Rooms.Add(Room1);
        Rooms.Add(Room2);
    }

    // Update is called once per frame
    void Update()
    {

        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);

        if(!playerInSight)Patrol();
        if (playerInSight) Chase();
    }

    void Chase()
    {
        agent.SetDestination(Player.transform.position);
    }

    void Patrol()
    {
        if (!walkpointSet) SearchForDes();
        if (walkpointSet) agent.SetDestination(desPoint);
        //if (Vector3.Distance(transform.position, desPoint) < 1) walkpointSet = false ;
    }

    void SearchForDes()
    {
        
        targetIndex = Random.Range(0, Rooms[currentRoomIndex].Count);
        desPoint = Rooms[currentRoomIndex][targetIndex].transform.position;
        walkpointSet = true;

        currentDestination = Instantiate(destinationPrefab, desPoint, destinationPrefab.transform.rotation);
    }
    public void RoomChange()
    {
        print("Room Change");
        if (currentRoomIndex == 0)
        {
            currentRoomIndex = 1;
        }
        else if (currentRoomIndex == 1)
        {
            currentRoomIndex = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destination"))
        {
            walkpointSet = false;
            Destroy(other.gameObject);
        }
    }

}
