using UnityEngine;
using System.Collections;

public class CompletedBrodcaster : MonoBehaviour {

    public string landMarkId;

	// Use this for initialization
	void Start () {
        EventManager.OnMapUnlocked(landMarkId);
	}
}
