using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemaster : MonoBehaviour
{
    public GameObject titleCanvas;
    public GameObject tutorialCanvas;

    private bool titleScreen = true;
    public string nextsceneName;
    public float screenTime = 5f;


    private void Start()
    {
        titleCanvas.SetActive(true);
        tutorialCanvas.SetActive(false);
    }



    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && titleScreen)
        {            
            titleScreen = false;
            titleCanvas.SetActive (false);
            tutorialCanvas.SetActive(true);
            Invoke("LoadNextScene", screenTime);
        }



    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextsceneName);
    }
}
