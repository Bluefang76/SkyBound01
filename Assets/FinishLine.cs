using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public GamePlayManager gamePlayManager;
    public TextMeshProUGUI finishText;
    public TextMeshProUGUI finishText2;

    private void Start()
    {
        finishText.text = "Player One Wins!!";
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)// Player
        {
            Debug.Log("Play Hit FinishLine ");
            Player2DMovement player = col.gameObject.GetComponent<Player2DMovement>();
            gamePlayManager.EndGame(player);
        }
    }
}
