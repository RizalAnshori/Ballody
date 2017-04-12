using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    public Level levelManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Reset()
    {
        levelManager.ResetMap();
    }

    public void Check()
    {
        levelManager.StartCoroutine("LevelCheckImpl");
        //levelManager.LevelCheckImpl();
        Debug.Log("Cek Called");
    }
}
