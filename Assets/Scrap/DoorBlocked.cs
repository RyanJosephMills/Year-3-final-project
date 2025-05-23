using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlocked : MonoBehaviour
{
    //https://youtube.com/watch?v=BS1wH0mYvJY&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=5&t=12s
    // Start is called before the first frame update

    public GameObject keyOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public GameObject HintCollider;
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    public bool inReach;
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.IsInteractPressed && inReach && playerMovement.canMove)
        {
            keyOB.SetActive(false);
            invOB.SetActive(true);
            pickUpText.SetActive(false);
            HintCollider.SetActive(true);
        }
    }
}
