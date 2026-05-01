using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.BoolParameter;



public class EnemyAppearCode : MonoBehaviour
{
    public GameObject enemyCharacter;
    public float displayTime = 1f;
    public AudioSource Lightning;
    // Start is called before the first frame update
    void Start()
    {
        enemyCharacter.SetActive(false);
        Lightning.Stop();
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
        enemyCharacter.SetActive(true);
        Lightning.Play();
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        enemyCharacter.SetActive(false);
        Destroy(gameObject);

    }
}
