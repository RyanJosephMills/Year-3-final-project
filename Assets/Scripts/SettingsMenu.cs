using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    PlayerMovement playerMovement;
    Resolution[] resolutions;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    public Dropdown resolutionsDropdown;

    // Start is called before the first frame update
    void Start()
    {
       resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }

        resolutionsDropdown.AddOptions(options);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex,false);
        
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

}