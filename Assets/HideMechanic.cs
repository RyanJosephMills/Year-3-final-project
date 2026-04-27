using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMechanic : MonoBehaviour
{
    PlayerMovement playerMovement;
    enemyAiPartrol canSeeTheEnemy;


    public bool inReach;
    public GameObject hideText;
    public Transform oB;
    public Transform[] spawnPoint;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        canSeeTheEnemy = FindObjectOfType<enemyAiPartrol>();
    }
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.IsInteractPressed && inReach)
        {
            int indexNumber = Random.Range(0, spawnPoint.Length);
            oB.position = spawnPoint[indexNumber].position;
            FindAnyObjectByType<enemyAiPartrol>().playerInSight = false;
            Debug.Log("Hiding");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            hideText.SetActive(true);
            Debug.Log("Collider");

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            hideText.SetActive(false);
            Debug.Log("NoCollider");
        }
    }
}
