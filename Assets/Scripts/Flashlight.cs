using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
    // Video of the code https://www.youtube.com/watch?v=xaJsStZp0kU&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&t=83s

    public Light light;

    public TMP_Text FlashlightLifetime;

    PlayerMovement playerMovement;

    public TMP_Text batteryText;

    public float lifetime = 100;

    public float batteries = 0;

    public bool on;

    public float BatteryDrop;

    public float IntensityDrop;

    public bool HasFlashlight = false;

    public GameObject battery;
    public GameObject battery1;
    public GameObject battery2;
    public GameObject battery3;
    public GameObject battery4;



    void Start()
    {
        FlashlightLifetime.text = "Flashlight : " + lifetime + "%";
        light = GetComponent<Light>();
        light.enabled = false;
        light.intensity = 25;
        battery.SetActive(true);
        battery1.SetActive(false);
        battery2.SetActive(false);
        battery3.SetActive(false);
        battery4.SetActive(false);


    }
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        FlashlightLifetime.text = lifetime.ToString("0") + "%";
        batteryText.text = batteries.ToString();

        light.enabled = playerMovement.IsFlashlightPressed;
        on = playerMovement.IsFlashlightPressed;

        if (HasFlashlight)
        {
            TriggerFlashlightVariables();
        }
        
    }


    private void TriggerFlashlightVariables()
    {
        if (on)
        {
            lifetime -= BatteryDrop * Time.deltaTime;
            light.intensity -= IntensityDrop * Time.deltaTime;
        }
        if (lifetime <= 0)
        {
            light.enabled = false;
            lifetime = 0;
            light.intensity = 0;
        }
        if (lifetime >= 100)
        {
            lifetime = 100;
            light.intensity = 25;
        }
        if (playerMovement.IsReloadPressed && batteries >= 1 && playerMovement.canMove)
        {
            playerMovement.IsReloadPressed = false;
            if (lifetime != 100)
            {
                batteries -= 1;
                lifetime += 25;
                light.intensity += 25;

            }
        }
        if (lifetime == 100)
        {
            battery.SetActive(true);
        }
        if (lifetime <= 75)
        {
            battery.SetActive(false);
            battery1.SetActive(true);
        }
        if (lifetime <= 50)
        {
            battery1.SetActive(false);
            battery2.SetActive(true);
        }
        if(lifetime <= 25)
        {
            battery2.SetActive(false);
            battery3.SetActive(true);
        }
        if (lifetime <= 0)
        {
            battery3.SetActive(false);
            battery4.SetActive(true);
        }
        if (playerMovement.IsReloadPressed && batteries == 0)
        {
            playerMovement.IsReloadPressed = false;
            return;
        }
        if (batteries <= 0)
        {
            batteries = 0;
        }
    }
}
