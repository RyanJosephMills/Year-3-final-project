using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class DoorScript : MonoBehaviour
{
    // https://www.youtube.com/watch?v=oCv14L3Ew4w&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=3
    // https://www.youtube.com/watch?v=KEWihN-qm1M&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=13
    // Start is called before the first frame update

    public Animator Door;
    public GameObject openText;
    public GameObject KeyINV;
    public GameObject KeyINV2;
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

    void Start()
    {
        inReach = false;
        unlocked = false;
        locked = true;
        hasKey = false;
        EnemyInReach = false;
        doorTextTimer = 1;
        DoorClosed();
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
            Debug.Log("calling");
            EnemyInReach = true;
            DoorOpen();
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
            Debug.Log("not calling");
            EnemyInReach = false;
            DoorClosed();
        }

    }

    // Update is called once per frame
    void Update()
    {
        hasKey = (KeyINV && KeyINV2.activeInHierarchy);

        if (playerMovement.IsInteractPressed && inReach)
        {
            DoorIsOpen = unlocked ? !DoorIsOpen : false;
            doorTextTimer = unlocked ? 1.3f : 0f;
            unlocked = hasKey;
            
            CheckDoor();
            
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
        if (doorTextTimer < 1.2)
        {
            doorLocked.SetActive(!unlocked);
            doorUnlocked.SetActive(unlocked);
            doorTextTimer+=Time.deltaTime;
            if (doorTextTimer > 1)
            {
                doorLocked.SetActive(false);
                doorUnlocked.SetActive(false);
                doorTextTimer = 1.3f;
            }
        }
    }

    void DoorOpen()
    {
        Door.SetBool("Open", true);
    }
    void DoorClosed()
    {
        Door.SetBool("Open", false);
    }

}
