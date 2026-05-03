using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.BoolParameter;
public class MainMenu : MonoBehaviour
{
    public GameObject introMenu;
    public float displayTime = 1f;
    public GameObject mainMenu;
    public void PlayGame()
    {
        StartCoroutine(ShowAndHideImage());

    }
    public void QuitGame()
    {
        Debug.Log("Quiting game....");
        Application.Quit();
    }
    IEnumerator ShowAndHideImage()
    {
        introMenu.SetActive(true);
        mainMenu.SetActive(false);
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        SceneManager.LoadScene("SampleScene");
    }
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
