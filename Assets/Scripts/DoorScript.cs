using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // https://www.youtube.com/watch?v=oCv14L3Ew4w&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=3
    // https://www.youtube.com/watch?v=KEWihN-qm1M&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=13
    // Start is called before the first frame update

    public Animator Door;
    public GameObject openText;
    public GameObject KeyINV;
    public GameObject KeyINV2;
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;

    void Start()
    {
        inReach = false;
        unlocked = false;
        locked = true;
        hasKey = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (KeyINV && KeyINV2.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }

        if (playerMovement.IsInteractPressed && inReach && playerMovement.canMove && hasKey)
        {
            unlocked = true;
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }
    }
    void DoorOpens()
    {
        Door.SetBool("Open", true);
        Door.SetBool("Closed", false);
    }    
    void DoorCloses()
    {
        Door.SetBool("Open", false);
        Door.SetBool("Closed", true);
    }
}
