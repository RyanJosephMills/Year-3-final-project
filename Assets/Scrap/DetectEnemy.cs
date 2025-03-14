using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{

    public DoorScript doorScript;

    private bool DoorWasOpen;



    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DoorWasOpen = doorScript.DoorIsOpen;
            doorScript.EnemyInReach = true;
            doorScript.CheckDoor();
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!DoorWasOpen)
            {
                doorScript.DoorIsOpen = false;
                doorScript.EnemyInReach = false;
                doorScript.CheckDoor();
            }
        }
    }

}
