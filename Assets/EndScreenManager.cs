using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{

    public string titleScene;
    public string gameScene;
    public float screenTime;


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("Quit", screenTime);
        }

        if ((Input.GetKeyDown(KeyCode.A)) || Input.GetKeyDown(KeyCode.D))
        {
            Invoke("PlayAgain", screenTime);
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
