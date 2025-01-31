using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offsetflashlight : MonoBehaviour
{

    private Vector3 vectOffset;
    private GameObject gofollow;
    [SerializeField] private float speed = 3.0f;

    void Start()
    {
        gofollow = Camera.main.gameObject;
        vectOffset = transform.position = gofollow.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = gofollow.transform.position + vectOffset;
        transform.rotation = Quaternion.Slerp(transform.rotation, gofollow.transform.rotation, speed + Time.deltaTime);
    }
}
