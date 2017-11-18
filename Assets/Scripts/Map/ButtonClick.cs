using UnityEngine;
using System.Collections;
using MadLevelManager;

public class ButtonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void argument()
    {
		if (MadLevelProfile.IsCompleted ("Level 1")) {
			Debug.Log("Clicked");
			Debug.Log(MadLevel.arguments);
		}
        
    }

	public void complete()
	{
		MadLevelProfile.SetCompleted ("Level 1",true);
	}
}
