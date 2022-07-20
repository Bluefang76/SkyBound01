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
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
