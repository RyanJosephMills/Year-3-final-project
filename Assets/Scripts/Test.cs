using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;



public class Test : MonoBehaviour

{
    // this code was from a tutorial however I am unable to locate that video
    GameObject Player;

    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    //patrol
    Vector3 desPoint;
    bool walkpointSet;
    [SerializeField] float range;

    //state change
    [SerializeField] float sightRange;
    bool playerInSight;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        Patrol();
    }
    void Patrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(desPoint);
        if (Vector3.Distance(transform.position, desPoint) < 1) walkpointSet = false;

    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        desPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(desPoint,Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }







    // Start is called before the first frame update
    /*void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
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
        if (Vector3.Distance(transform.position, desPoint) < 0.05f) walkpointSet = false ;
    }

    void SearchForDes()
    {
        float z = Random.Range(-range , range);
        float x = Random.Range(-range , range);

        desPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        if (Physics.Raycast(desPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }*/

}
