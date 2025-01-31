using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsColiding : MonoBehaviour
{
    public GameObject boxCast;
    private bool hitDetect;

    public float maxDistance;

    private Collider myCollider;

    private RaycastHit hit;
    private bool touchingDoor = true;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = boxCast.GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hitDetect = Physics.BoxCast(myCollider.bounds.center, transform.localScale * 0.5f, -transform.right, out hit,
            transform.rotation, maxDistance,layerMask);
        if (hitDetect)
        {
            if (hit.collider.tag == "Door")
            {
                print("Touching door");
                touchingDoor = true;
            }
            
        }
        else
        {
            touchingDoor = false;
        }
    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (hitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(boxCast.transform.position, transform.up * hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(boxCast.transform.position + -transform.right * hit.distance, boxCast.transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(boxCast.transform.position, -transform.right * maxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(boxCast.transform.position + -transform.right * maxDistance, boxCast.transform.localScale);
        }
    }

    public bool IsTouchingDoor()
    {
        return touchingDoor;
    }
}
