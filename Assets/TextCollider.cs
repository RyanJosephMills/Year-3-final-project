using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollider : MonoBehaviour
{
    public bool inReach;
    public GameObject HintTextUI;
    public GameObject ColliderUI;

    // Start is called before the first frame update
    void Start()
    {
        {
            inReach = false;

            ColliderUI.SetActive(false);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Location")
        {
            inReach = true;
            HintTextUI.SetActive(true);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Location")
        {
            inReach = false;
           HintTextUI.SetActive(false);
           Destroy(gameObject);
        }
    }
}
