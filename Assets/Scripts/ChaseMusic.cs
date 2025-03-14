using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMusic : MonoBehaviour
{
    public AudioSource Chase;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Chase.Play();
        }
        else
        {
            Chase.Stop();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Chase.Stop();
        }
    }

}
