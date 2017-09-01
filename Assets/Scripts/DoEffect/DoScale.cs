using UnityEngine;
using DG.Tweening;
using System.Collections;

public class DoScale : MonoBehaviour {

    public Vector3 endValue, startValue;
    public float duration;

	// Use this for initialization
	void OnEnable () {
        Enable();
	}

    void OnDisable()
    {
        this.transform.localScale = startValue;
    }

    public void Enable()
    {
        this.transform.localScale = startValue;
        this.transform.DOScale(endValue, duration);
    }
}
