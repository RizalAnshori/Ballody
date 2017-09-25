using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DoFade : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public float duration;

	// Use this for initialization
	void OnEnable()
    {
        spriteRenderer.DOFade(0, duration).SetLoops(-1, LoopType.Yoyo);
	}
}
