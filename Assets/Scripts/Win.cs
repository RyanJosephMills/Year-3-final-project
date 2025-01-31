using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject pickUpText;
    public bool inReach;
    PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.IsInteractPressed && inReach && playerMovement.canMove)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Location")
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Location")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }
}
