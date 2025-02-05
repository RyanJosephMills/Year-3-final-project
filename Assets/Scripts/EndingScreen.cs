using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndingScreen : MonoBehaviour
{
    public GameObject EndingScreenUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        EndingScreenUI.SetActive(false);

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        EndingScreenUI.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quiting game....");
        Application.Quit();
    }
}
