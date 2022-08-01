using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Vector3 maxHeight;
    public float smoothTime = 1;

    Vector3 velocity;

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, maxHeight, ref velocity, smoothTime);
    }
}
