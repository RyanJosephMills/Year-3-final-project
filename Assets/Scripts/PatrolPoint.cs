using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PointType
{
    patrolPoint,
    doorPoint
}

public class PatrolPoint : MonoBehaviour
{
    public enemyAiPartrol Enemy;
    private MeshRenderer mesh;
    public PointType pointType = PointType.patrolPoint;
        
  // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            
            if(pointType == PointType.doorPoint)
            {
                print("Door Point");
                bool touching = GetComponent<IsColiding>().IsTouchingDoor();
                if (touching == false)
                {
                    Enemy.RoomChange();
                }
            }
            
        }
    }
}
