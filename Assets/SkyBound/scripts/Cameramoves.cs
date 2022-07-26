using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramoves : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }





    public Transform target;
    public float smoothSpeed = 0.05f;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        

        //transform.LookAt(target);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
}
