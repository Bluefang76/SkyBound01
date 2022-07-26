using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffed : MonoBehaviour
{

    public float bufferTime = 1f;
    public List<InputStorage> inputBuffer = new List<InputStorage>();
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputStorage inputStorage = new InputStorage();
            inputStorage.inputTime = Time.time;
            inputStorage.inputKey = KeyCode.Space;
            inputBuffer.Add(inputStorage);

        }
    }

    public bool GetInput(KeyCode keyCode)
    {
        bool hasInput = false;

        ClearBuffer();
        for (int i = 0; i < inputBuffer.Count; i++)
        {
            if (inputBuffer[i].inputKey != keyCode)
                continue;

            inputBuffer.Remove(inputBuffer[i]);
            hasInput = true;
            break;        
        }

        return hasInput;
    }

    void ClearBuffer()
    {
        InputStorage[] inputStorageArray = new InputStorage[inputBuffer.Count];
        // setting an arry to the size of our list
        for (int i = 0; i < inputBuffer.Count; i++)
        {
            inputStorageArray[i] = inputBuffer[i];
        }

        for (int i = 0; i < inputStorageArray.Length; i++)
        {
            float diff =  Time.time - inputStorageArray[i].inputTime;
            if (diff < bufferTime)
                continue;

            inputStorageArray[i] = null;
        }

        inputBuffer.Clear();
        inputBuffer = new List<InputStorage>();

        for (int i = 0; i < inputStorageArray.Length; i++)
        {
            if (inputStorageArray[i] != null)
                inputBuffer.Add(inputStorageArray[i]);
        }
    }
}

[System.Serializable]
public class InputStorage
{
    public float inputTime;
    public KeyCode inputKey;
}