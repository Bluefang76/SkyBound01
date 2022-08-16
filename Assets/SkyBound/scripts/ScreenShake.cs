using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Transform camera;
    public Vector3 orignalPosition;
    public float _duration;
    public float _magnitude;

    Coroutine coroutine;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(Shake(_duration, _magnitude));
        }
    }

    public void StartShake()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(Shake(_duration, _magnitude));
    }


    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            camera.localPosition = Vector3.Lerp(camera.localPosition, new Vector3(x, y, -0f), Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        camera.localPosition = orignalPosition;
    }





}