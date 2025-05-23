using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem;

public class PickUpFlashlight : MonoBehaviour
{
    public GameObject FlashlightObject;
    public GameObject FlashlightLight;
    public GameObject Batteries;
    public GameObject BatteriesLife;
    public GameObject PickUpFlashlightText;
    public bool inReach;
    public GameObject pickUpText;
    PlayerMovement playerMovement;
    // Start is called before the first frame update

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    void Start()
    {
        FlashlightLight.SetActive(false);
        FlashlightObject.SetActive(false);
        Batteries.SetActive(false);
        BatteriesLife.SetActive(false);
        PickUpFlashlightText.SetActive(true);
        inReach = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.IsInteractPressed && inReach && playerMovement.canMove)
        {
            FlashlightObject.SetActive(true);
            FlashlightLight.SetActive(true);
            Batteries.SetActive(true);
            BatteriesLife.SetActive(true);
            PickUpFlashlightText.SetActive(false);
            Destroy(gameObject);
            pickUpText.SetActive(false);
            FindObjectOfType<Flashlight>().HasFlashlight = true;
        }
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
}
