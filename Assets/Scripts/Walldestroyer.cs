using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walldestroyer : MonoBehaviour
{
    public GameObject KeyINV;
    public GameObject destroyText;
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        unlocked = false;
        locked = true;
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyINV.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        }
        if (playerMovement.IsInteractPressed && inReach && playerMovement.canMove && hasKey)
        {
            Destroy(gameObject);
            destroyText.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            destroyText.SetActive(true);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            destroyText.SetActive(false);
        }
    }
}
