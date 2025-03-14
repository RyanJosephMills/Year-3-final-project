using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDoorOpen : MonoBehaviour
{
    public bool EnemyInReach;
    public Animator Door;
    // Start is called before the first frame update
    void Start()
    {
        EnemyInReach = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AIReach")
        {
            EnemyInReach = true;
            DoorOpens();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "AIReach")
        {
            EnemyInReach = false;
            DoorOpens();
        }
    }
    void DoorOpens()
    {
        Door.SetBool("Open", true);
        Door.SetBool("Closed", false);
    }
    void DoorCloses()
    {
        Door.SetBool("Open", false);
        Door.SetBool("Closed", true);
    }

}
