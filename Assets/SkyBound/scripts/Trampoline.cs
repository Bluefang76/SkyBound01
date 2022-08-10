using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trampoline : MonoBehaviour
{
    [Header("Hit FX")]
    public Color[] hitColor;
    [Space]

    [Header ("Bounce FX")]
    public Transform anchor;

    public SpriteRenderer spriteRenderer;
    public Vector3[] scale;
    public float scaleTime;

    Sequence sequence;

    public void Hit()
    {

        Debug.Log("Hit trampoline");
        if (sequence != null)
            sequence.Complete();

        sequence = DOTween.Sequence();

        float duration = scaleTime / hitColor.Length;

        for (int i = 0; i < hitColor.Length; i++)
        {
            sequence.Insert(duration * i, spriteRenderer.DOColor(hitColor[i], duration).SetEase(Ease.OutQuad));
        }


        sequence.SetLoops(2, LoopType.Restart);
        sequence.Play();
    }

    public void DoEffect()
    {
        if (sequence != null)
            sequence.Complete();

        sequence = DOTween.Sequence();

        float duration = scaleTime / scale.Length;

        for (int i = 0; i < scale.Length; i++)
        {
            sequence.Insert(duration * i, anchor.DOScale(scale[i], duration).SetEase(Ease.OutQuad));
        }

        sequence.Play();
    }
}
