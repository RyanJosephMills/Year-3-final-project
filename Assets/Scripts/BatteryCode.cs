using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCode : MonoBehaviour

// https://www.youtube.com/watch?v=xaJsStZp0kU&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=29
{
    private bool inReach;

    public GameObject pickUpText;
    private GameObject flashlight;
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        flashlight = GameObject.Find("flashlight");
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




    void Update()
    {
        if (playerMovement.IsInteractPressed && inReach && playerMovement.canMove)
        {
            flashlight.GetComponent<Flashlight>().batteries += 1;
            inReach = false;
            pickUpText.SetActive(false);
            Destroy(gameObject);
        }

    }
}