using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public KeyCode jumpButton;
    public KeyCode jumpButton2;
    public string titleScene;
    public string gameScene;
    public float screenTime;
    private bool buttonPressed = false;


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
             return;

        if (Input.GetKeyDown(jumpButton) || Input.GetKeyDown(jumpButton2))
        {
            Invoke("Quit", screenTime);
            buttonPressed = true;
        }
      
        if ((Input.GetKeyDown(KeyCode.A)) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Invoke("PlayAgain", screenTime);
            buttonPressed = true;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Quit()
    {
        SceneManager.LoadScene(titleScene);
    }
}
