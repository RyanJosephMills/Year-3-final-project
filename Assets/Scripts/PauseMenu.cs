using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PauseMenu : MonoBehaviour

// https://www.youtube.com/watch?v=JivuXdrIHK0&t=523s
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject BatteryUI;
    public GameObject BatteryLife;
    public GameObject NoteUI;
    public GameObject SettingsUI;
    public GameObject OptionsUI;
    public GameObject ControlsUI;
    public GameObject StaminaUI;
    public GameObject ObjectiveText;
    public GameObject FlashLightObjectiveText;
    public GameObject CameraUI;
    public GameObject NoteNewUi;
    public GameObject imageObject;
    public GameObject OpeningObjective;
    public GameObject FinalObjective;
    public AudioSource GameAudio;
    public AudioSource Wind;
    public AudioSource FootSteps;
    public AudioSource CreepyMusic;
    PlayerMovement playerMovement;
    MainDoor mainDoor;
    public GameObject Line;
    public GameObject Line1;
    public GameObject Line2;
    public GameObject Line3;
    public GameObject OpenClose;
    Flashlight Player;
    public float Note = 0;
    public TMP_Text NoteText;

    void Start()
    {

    }
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();

        Player = FindAnyObjectByType<Flashlight>();

        mainDoor = FindObjectOfType<MainDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        NoteText.text = Note.ToString();
        if (playerMovement.IsMenuPressed)
        {
            if (GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();

            }
            playerMovement.IsMenuPressed = false;
        }
    }
   public void Resume()
    {
        PauseMenuUI.SetActive(false);
        SettingsUI.SetActive(false);
        ControlsUI.SetActive(false);
        OptionsUI.SetActive(false);
        CameraUI.SetActive(true);
        StaminaUI.SetActive(true);
        OpenClose.SetActive(true);
        ObjectiveText.SetActive(false);
        FlashLightObjectiveText.SetActive(false);
        GameAudio.Play();
        Wind.Play();
        CreepyMusic.Play();
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerMovement.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        CameraUI.SetActive(false);
        OpenClose.SetActive(false);
        StaminaUI.SetActive(false);
        imageObject.SetActive(false);
        OpeningObjective.SetActive(false);
       
        if (mainDoor.KeyINV5.activeInHierarchy)
        {
            FinalObjective.SetActive(true);
            Line1.SetActive(true);
            Line2.SetActive(true);
            Line3.SetActive(true);
        }
        else
        {
            FinalObjective.SetActive(false);
            Line1.SetActive(false);
            Line2.SetActive(false);
            Line3.SetActive(false);
        }

        if (!Player.HasFlashlight)
        {
            FlashLightObjectiveText.SetActive(true);
            ObjectiveText.SetActive(false);
            NoteNewUi.SetActive(false);
            Line.SetActive(false);
        }
        else if (Player.HasFlashlight)
        {
            Line.SetActive(true);
            ObjectiveText.SetActive(true);
            NoteNewUi.SetActive(true);
            FlashLightObjectiveText.SetActive(true);
        }

        GameAudio.Pause();
        Wind.Pause();
        FootSteps.Pause();
        CreepyMusic.Pause();
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerMovement.canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("Quiting game....");
        Application.Quit();
    }
}
