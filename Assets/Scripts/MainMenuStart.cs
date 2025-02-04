using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject OptinMenuUI;
    public void Start()
    {
        MainMenuUI.SetActive(true);
        OptinMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
