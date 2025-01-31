using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public Light lightOB;

    public float minTime;
    public float maxTime;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        LightFlickering();
    }

    void LightFlickering()
    {
        if (timer > 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            lightOB.enabled = !lightOB.enabled;
            timer = Random.Range(minTime, maxTime);
        }
    }
}