using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemaster : MonoBehaviour
{
    private bool titleScreen = true;
    private bool game;
    private bool win1;
    private bool win2;
    public string nextsceneName;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextsceneName);
            titleScreen = false;
        }



    }
}
