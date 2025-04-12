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
    //   public GameObject BatteriesLife;
    //   public GameObject PickUpFlashlightText;
    public bool inReach;
    public GameObject pickUpText;
    PlayerMovement playerMovement;
    public GameObject battery1;
    public GameObject batteryText;
    public GameObject ItemHolder;
    public GameObject imageObject;
    public float displayTime = 3f;
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
        batteryText.SetActive(false);
        battery1.SetActive(false);
        ItemHolder.SetActive(false);
        inReach = false;
        imageObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.IsInteractPressed && inReach && playerMovement.canMove)
        {
            FlashlightObject.SetActive(true);
            FlashlightLight.SetActive(true);
            Batteries.SetActive(true);
            battery1.SetActive(true);
            Destroy(gameObject);
            pickUpText.SetActive(false);
            FindObjectOfType<Flashlight>().HasFlashlight = true;
            ItemHolder.SetActive(true);
            imageObject.SetActive(true);
            batteryText?.SetActive(true);
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
