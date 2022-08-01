using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trampoline : MonoBehaviour
{
    Sequence sequence;
    public Transform anchor;
    public void DoEffect()
    {
        Debug.Log("Do Effect");
        if (sequence != null)
            sequence.Complete();

        sequence = DOTween.Sequence();

        sequence.Insert(0, anchor.DOScaleY(1.25f, .33f).SetEase(Ease.OutQuad));
        sequence.Insert(.33f, anchor.DOScaleY(0.85f, .33f).SetEase(Ease.OutQuad));
        sequence.Insert(.66f, anchor.DOScaleY(1f, .33f).SetEase(Ease.OutQuad));


        sequence.Play();
    }
}
