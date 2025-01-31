using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationText : MonoBehaviour

{
    public GameObject Location;
    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Location")
        {
            inReach = true;
            Location.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Location")
        {
            inReach = false;
            Location.SetActive(false);
        }
    }
}
