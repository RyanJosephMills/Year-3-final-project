using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCode : MonoBehaviour
{
    PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    public bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    void Update()
    {
        if (inReach)
        {
            SceneManager.LoadScene("Lose");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {
            inReach = true;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {
            inReach = false;
        }
    }
}
