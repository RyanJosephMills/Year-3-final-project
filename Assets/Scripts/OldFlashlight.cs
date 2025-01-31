using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldFlashlight : MonoBehaviour
{

    public GameObject flashlight;

    public bool on;
    public bool off;

    void Start()
    {
        off = true;
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (off && Input.GetButtonDown("F"))
        {
            flashlight.SetActive(true);
            off = false;
            on = true;
        }
        else if (on && Input.GetButtonDown("F"))
        {
            flashlight.SetActive(false);
            off = true;
            on = false;
        }
    }
}
