using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.BoolParameter;
public class WinScreen : MonoBehaviour
{
    public GameObject EndingScreenUI;
    public AudioSource DoorClose;
    public AudioSource GirlLaugh;
    public float displayTime = 1f;
    public float displayTime2 = 10f;

    // Start is called before the first frame update
    void Start()
    {
        GirlLaugh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShowAndHideImage());
    }
    IEnumerator ShowAndHideImage()
    {
        DoorClose.enabled = true;
        yield return new WaitForSeconds(displayTime2); // Wait for the specified time
        GirlLaugh.enabled = true;
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        SceneManager.LoadScene("MainMenu");
    }
}
