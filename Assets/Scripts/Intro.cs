using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.BoolParameter;
public class Intro : MonoBehaviour
{
    public GameObject Story;
    public AudioSource GirlScream;
    public float displayTime = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Story)
        {
            StartCoroutine(ShowAndHideImage());
        }

    }
    IEnumerator ShowAndHideImage()
    {
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        SceneManager.LoadScene("SampleScene");
    }
    
}
