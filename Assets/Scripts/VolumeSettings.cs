using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider mySlider;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }

  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMusicVolume()
    {
        float volume = mySlider.value;
        myMixer.SetFloat("Volume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat ("musicVolume", volume);
    }
    private void LoadVolume()
    {
        mySlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
