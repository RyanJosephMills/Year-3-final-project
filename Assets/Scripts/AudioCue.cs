using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioCue : MonoBehaviour
{
    public AudioSource AudioSound;
    // Start is called before the first frame update
    void Start()
    {
        AudioSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            AudioSound.Play();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
