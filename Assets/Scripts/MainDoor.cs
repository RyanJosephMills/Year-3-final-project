using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour
{
    // https://www.youtube.com/watch?v=oCv14L3Ew4w&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=3
    // https://www.youtube.com/watch?v=KEWihN-qm1M&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=13
    // Start is called before the first frame update

    public Animator Door;
    public GameObject openText;
    public GameObject KeyINV;
    public GameObject KeyINV2;
    public GameObject KeyINV3;
    public GameObject KeyINV4;
    public GameObject KeyINV5;
    public GameObject KeyINV6;
    public GameObject KeyINV7;

    public GameObject[] KeyInv;

    public GameObject doorLocked;
    public GameObject doorUnlocked;
    PlayerMovement playerMovement;


    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;
    public bool EnemyInReach;


    public float doorTextTimer = 1;

    public bool DoorIsOpen;


    private void CheckKeys()
    {
        bool hasAllKeys = true;
        foreach(GameObject key in KeyInv)
        {
            //if he hasnt got this key set hasAllKeys to false;
        }
        if (hasAllKeys)
        {
            //opendoor
        }
    }

    void Start()
    {
        inReach = false;
        unlocked = false;
        locked = true;
        hasKey = false;
        EnemyInReach = false;
        doorTextTimer = 1;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
        if (other.gameObject.tag == "AIReach")
        {
            EnemyInReach = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            doorLocked.SetActive(false);
            doorUnlocked.SetActive(false);
        }
        if (other.gameObject.tag == "AIReach")
        {
            EnemyInReach = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        hasKey = (KeyINV && KeyINV2.activeInHierarchy);

        if (playerMovement.IsInteractPressed && inReach)
        {
            DoorIsOpen = unlocked ? !DoorIsOpen : false;
            unlocked = hasKey;

            CheckDoor();
            doorTextTimer = 0;
        }
        else if (EnemyInReach)
        {
            DoorIsOpen = true;
            CheckDoor();
        }
        DoorTextTimer();

    }
    public void CheckDoor()
    {
        Door.SetBool("Open", DoorIsOpen);
    }


    public void DoorTextTimer()
    {
        if (doorTextTimer != 1)
        {
            doorLocked.SetActive(!unlocked);
            doorUnlocked.SetActive(unlocked);
            doorTextTimer += Time.deltaTime;
            if (doorTextTimer > 1)
            {
                doorLocked.SetActive(false);
                doorUnlocked.SetActive(false);
                doorTextTimer = 1;
            }
        }
    }

}

