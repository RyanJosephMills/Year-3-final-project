using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.BoolParameter;

public class AudioCue : MonoBehaviour
{
    public AudioSource AudioSound;
    public float displayTime = 1f;
    public GameObject SelfObject;
    public GameObject NextScare;
    public GameObject ActualSound;
    // Start is called before the first frame update
    void Start()
    {

        AudioSound.Stop();
        NextScare.SetActive(false);
        ActualSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            StartCoroutine(ShowAndHideImage());
        }

    }
    IEnumerator ShowAndHideImage()
    {
        ActualSound.SetActive(true);
        NextScare.SetActive(true);
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        SelfObject.SetActive(false);

    }
}
