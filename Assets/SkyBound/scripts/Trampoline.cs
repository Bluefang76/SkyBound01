using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trampoline : MonoBehaviour
{
    [Header("Hit FX")]
    public Color[] hitColor;
    [Space]

    [Header("Bounce FX")]
    public ParticleSystem particleSystem;
    public Transform anchor;

    public SpriteRenderer spriteRenderer;
    public Vector3[] scale;
    public float scaleTime;

    Sequence sequence;

    public AudioSource audiosource;
    public AudioClip soundboing;
    public AudioClip landsound;

    public void Hit()
    {
        audiosource.PlayOneShot(landsound);
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
        particleSystem.Play();
        audiosource.PlayOneShot(soundboing); 

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
