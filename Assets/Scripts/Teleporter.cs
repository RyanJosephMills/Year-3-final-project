using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

   // public Transform player, desternation;
    public GameObject playerg;
    PlayerMovement playerMovement;
    public bool inReach;
    public GameObject hideText;
    public Camera Camera1;
    public Camera Camera2;
    enemyAiPartrol EnemyCode;
    public AudioSource EnterWardrobe;
    public GameObject LeaveText;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        EnemyCode = FindObjectOfType<enemyAiPartrol>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            hideText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            hideText.SetActive(false);
            inReach = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        Camera1.gameObject.SetActive(true);
        Camera2.gameObject.SetActive(false);
        EnterWardrobe.Stop();
        LeaveText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.IsInteractPressed && inReach)
        {
            playerg.SetActive(false);
           // player.position = desternation.position;
            inReach = false;
            Camera1.gameObject.SetActive(!Camera1.gameObject.activeSelf);
            Camera2.gameObject.SetActive(!Camera2.gameObject.activeSelf);
            hideText.SetActive(false);
            EnemyCode.playerInSight = false;
            EnterWardrobe.Play();
            LeaveText.SetActive(true);

            
        }
    }
}
