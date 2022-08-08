using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public GameObject player1EndScreen;
    public GameObject player2EndScreen;

    public void EndGame(Player2DMovement player)
    {
        // We need to check the players index, (we will need to be added after a merge)
        // based off the players index we can change what the screen says

        if (player.playerIndex == 1)
        {
            player1EndScreen.SetActive(true);
        }
        else
        {
            player2EndScreen.SetActive(true);
        }

        // Game is over, freeze player movement
        // pause score
    }
}
