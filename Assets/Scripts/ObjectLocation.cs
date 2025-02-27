using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLocation : MonoBehaviour
{
    // https://www.youtube.com/watch?v=Zax9ZZmncIA&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=31

public Transform oB;
public Transform[] spawnPoint;

// Start is called before the first frame update
void Start()
{ 
    int indexNumber = Random.Range(0, spawnPoint.Length);
    oB.position = spawnPoint[indexNumber].position;
}

// Update is called once per frame
void Update()
    {
        
    }
}
