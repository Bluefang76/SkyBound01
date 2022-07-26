using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffEx : MonoBehaviour
{
    public bool isOnTrampoline;
    Buffed buffed;

    void Start()
    {
        buffed = FindObjectOfType<Buffed>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnTrampoline)
        {
            if (buffed.GetInput(KeyCode.Space))
            {
                isOnTrampoline = false;
            }

        }
    }
}
