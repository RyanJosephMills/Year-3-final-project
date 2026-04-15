using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.BoolParameter;
public class LoseScreen : MonoBehaviour
{
    public GameObject EndingScreenUI;
    public AudioSource GirlScream;
    public float displayTime = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShowAndHideImage());
    }
    IEnumerator ShowAndHideImage()
    {
        GirlScream.enabled = true;
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        SceneManager.LoadScene("MainMenu");
    }
}
