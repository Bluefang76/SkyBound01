using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.05f;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public Vector3 velocity = Vector3.zero;

    void Start()
    {
        transform.position = GetTargetOffsetPosition();
    }

    void Update()
    {      
        transform.position = Vector3.SmoothDamp(transform.position, GetTargetOffsetPosition(), ref velocity, smoothSpeed);
    }

    public Vector3 GetTargetOffsetPosition()
    {
       return (new Vector3(0f, target.position.y, 0) + offset);
    }
}
