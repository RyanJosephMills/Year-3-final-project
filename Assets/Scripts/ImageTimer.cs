using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTimer : MonoBehaviour
{
    public GameObject imageObject; // Drag your image GameObject here in the inspector
    public float displayTime = 1f; // Time in seconds the image will be visible

    void Start()
    {
        StartCoroutine(ShowAndHideImage());
    }

    IEnumerator ShowAndHideImage()
    {
        imageObject.SetActive(true); // Make the image visible
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        imageObject.SetActive(false); // Make the image invisible
    }
}
