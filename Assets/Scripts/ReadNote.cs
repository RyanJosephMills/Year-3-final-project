using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.BoolParameter;

public class ReadNote : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject hud;
    public GameObject keyOB;
    public GameObject invOB;
    PlayerMovement playerMovement;
    public static bool GameIsPaused = false;
    public float displayTime = 1f;
    public GameObject GhostGirl;
    public GameObject GhostGirlText;
    public GameObject keyOBParent;
    public GameObject keyOBChild;

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
        GhostGirl.SetActive(false);
        GhostGirlText.SetActive(false);
        invOB.SetActive(false);
        inReach = false;
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
//            keyOB.SetActive(false);
            invOB.SetActive(true);
            PickUpPaperSFX.Play();


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
        playerMovement.GetComponent<PlayerMovement>().Notes += 1;
        StartCoroutine(ShowAndHideImage());
        keyOBChild.SetActive(false);
        GhostGirlText.SetActive(true);

    }
    IEnumerator ShowAndHideImage()
    {
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        GhostGirl.SetActive(true);
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        keyOBParent.SetActive(false);
    }
}
