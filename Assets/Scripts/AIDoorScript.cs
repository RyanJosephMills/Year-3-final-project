using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDoorScript : MonoBehaviour
{
    // https://www.youtube.com/watch?v=oCv14L3Ew4w&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=3
    // https://www.youtube.com/watch?v=KEWihN-qm1M&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=13
    // Start is called before the first frame update

    public Animator Door;




    public bool inReach;


    void Start()
    {
        inReach = false;

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

    // Update is called once per frame
    void Update()
    {

        if (inReach)
        {

            DoorOpens();
        }
        else
        {
            DoorCloses();
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
