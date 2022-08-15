using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    public float timee;





    public void Update()
    {
        timee += Time.deltaTime;
        int minutes = Mathf.RoundToInt(timee / 60f);
        int seconds = Mathf.RoundToInt(timee % 60f);

        TimeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
