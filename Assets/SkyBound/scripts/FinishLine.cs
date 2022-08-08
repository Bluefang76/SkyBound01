using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{
    GamePlayManager gamePlayManager;
 
    private void Start()
    {
        gamePlayManager = FindObjectOfType<GamePlayManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)// Player
        {
            Debug.Log("Play Hit FinishLine ");
            MPlayer2DMovement player = col.gameObject.GetComponent<MPlayer2DMovement>();
            gamePlayManager.EndGame(player);
        }
    }
}
