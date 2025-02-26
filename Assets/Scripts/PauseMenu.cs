using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

// https://www.youtube.com/watch?v=JivuXdrIHK0&t=523s
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject BatteryUI;
    public GameObject BatteryHealthUI;
    public GameObject SettingsUI;
    public GameObject OptionsUI;
    public GameObject ControlsUI;
    public GameObject StaminaUI;
    PlayerMovement playerMovement;

    void Start()
    {

    }




    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
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
        BatteryUI.SetActive(true);
        BatteryHealthUI.SetActive(true);
        StaminaUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerMovement.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        BatteryUI.SetActive(false);
        BatteryHealthUI.SetActive(false);
        StaminaUI.SetActive(false);
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
