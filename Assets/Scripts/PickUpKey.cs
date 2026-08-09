using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.BoolParameter;

public class PickUpKey : MonoBehaviour
{
    //https://youtube.com/watch?v=BS1wH0mYvJY&list=PLlcgaDpDEvw05IgKGZo9FYA8Fo38RtAqH&index=5&t=12s
    // Start is called before the first frame update
    public GameObject keyOBParent;
    public GameObject keyOBChild;
    public GameObject invOB;
    public GameObject pickUpText;
    public GameObject EnemyAI;
    PlayerMovement playerMovement;
    public AudioSource PickUpKeySFX;
    public float displayTime = 1f;
    //    public GameObject NextScare;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    public bool inReach;
    void Start()
    {

        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
     //   NextScare.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
            Debug.Log("Collider");
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
            Debug.Log("NoCollider");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerMovement.IsInteractPressed && inReach && playerMovement.canMove)
        {
            StartCoroutine(ShowAndHideImage());
            PickUpKeySFX.Play();
            keyOBChild.SetActive(false);
            invOB.SetActive(true);
            pickUpText.SetActive(false);
            EnemyAI.SetActive(true);
            //     NextScare.SetActive(true);



        }
    }
    IEnumerator ShowAndHideImage()
    {
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        keyOBParent.SetActive(false);
        Debug.Log("Working");
    }
}
