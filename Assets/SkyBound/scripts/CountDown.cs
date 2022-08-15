using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{

    public MPlayer2DMovement player1;
    public MPlayer2DMovement player2;
    public GameObject countDowndisplay;
    public TextMeshProUGUI CountDowntxt;
    public string[] countDown;
    public Timer timer;
    

    // Start is called before the first frame update
    void Start()
    {

        countDown = new string[4];
        countDown[0] = "3";
        countDown[1] = "2";
        countDown[2] = "1";
        countDown[3] = "Go";
        CountDowntxt.text = countDown[0];
        
        StartCoroutine(CountDownDisplay());
       
    }


    
    IEnumerator CountDownDisplay()
    {
        player1.enabled = (false);
        player2.enabled = (false);

        yield return new WaitForSeconds(1);

        CountDowntxt.text = countDown[0];

        yield return new WaitForSeconds(1);

        CountDowntxt.text = countDown[1];

        yield return new WaitForSeconds(1);

        CountDowntxt.text = countDown[2];

        yield return new WaitForSeconds(1);

        CountDowntxt.text = countDown[3];

        yield return new WaitForSeconds(1);

        countDowndisplay.SetActive(false);
        player1.enabled = (true);
        player2.enabled = (true);
        timer.enabled = (true);
    }
}
