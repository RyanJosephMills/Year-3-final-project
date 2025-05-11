using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadNote : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject hud;
    public GameObject keyOB;
    public GameObject invOB;
    private GameObject NotePickup;
    PlayerMovement playerMovement;
    private GameObject NoteInMenu;
    public static bool GameIsPaused = false;

    public GameObject pickUpText;

    public bool inReach;

    public AudioSource PickUpPaperSFX;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        pickUpText.SetActive(false);
        invOB.SetActive(false);
        inReach = false;
        NoteInMenu = GameObject.Find("Pause Menu");
        PickUpPaperSFX.Stop();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        

        if (playerMovement.IsInteractPressed && inReach && playerMovement.canMove)
        {
            noteUI.SetActive(true);
            hud.SetActive(false);
            GameIsPaused = true;
            playerMovement.canMove = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            keyOB.SetActive(false);
            invOB.SetActive(true);
            PickUpPaperSFX.Play();
        //    NoteInMenu.GetComponent<PauseMenu>().Note += 1;
        }
    }        
    public void ExitButton()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        GameIsPaused = false;
        playerMovement.canMove = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        pickUpText.SetActive(false);

    }

}
