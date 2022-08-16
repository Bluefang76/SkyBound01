using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayManager : MonoBehaviour
{

    public MPlayer2DMovement player1;
    public MPlayer2DMovement player2;
    public GameObject player1EndScreen;
    public TextMeshProUGUI notyet;
    public GameObject player2EndScreen;
    public string nextsceneName;
    public float screenTime = 5f;

    bool restartCalled = false;


    public void EndGame(MPlayer2DMovement player)
    {

        //public List<> =
        // We need to check the players index, (we will need to be added after a merge)
        // based off the players index we can change what the screen says
        player1.enabled = (false);
        player2.enabled = (false);
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
