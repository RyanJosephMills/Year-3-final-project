using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DoorUnlockedSFX : MonoBehaviour
{
    public AudioSource DoorUnlockedSound;
    public bool inReach;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        DoorUnlockedSound.Stop();
        inReach = false;

    }

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerMovement.IsInteractPressed && inReach)
        {
            DoorUnlockedSound.Play();
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
        }
    }

}