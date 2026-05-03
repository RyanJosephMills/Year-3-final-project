using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Returntocamera : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;
    PlayerMovement playerMovement;
    public GameObject playerg;
    public GameObject hideText;
    public AudioSource EnterWardrobe;
    // Start is called before the first frame update
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
        void Start()
    {
        Camera1.gameObject.SetActive(false);
        Camera2.gameObject.SetActive(true);
        hideText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            playerg.SetActive(true);
            // player.position = desternation.position;
            Camera1.gameObject.SetActive(!Camera1.gameObject.activeSelf);
            Camera2.gameObject.SetActive(!Camera2.gameObject.activeSelf);
            hideText?.SetActive(false);
            EnterWardrobe.Play();
        }
    }
}
