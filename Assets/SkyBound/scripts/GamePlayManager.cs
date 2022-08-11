using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    
    
    public GameObject player1EndScreen;
    public GameObject player2EndScreen;
    public string nextsceneName;
    public float screenTime = 5f;

    bool restartCalled = false;


    public void EndGame(MPlayer2DMovement player)
    {
        // We need to check the players index, (we will need to be added after a merge)
        // based off the players index we can change what the screen says

        if (player.playerNumber == PlayerNumber.Player1)
        {
            player1EndScreen.SetActive(true);
        }
        else
        {
            player2EndScreen.SetActive(true);
        }    
        

        // Game is over, freeze player movement
        // pause score
 
        if (restartCalled)
            return;

        restartCalled = true;
        Invoke("RestartGame", screenTime);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(nextsceneName);


        
    }
    /*
    public void PlayLock()
    {

    }
    */


}
