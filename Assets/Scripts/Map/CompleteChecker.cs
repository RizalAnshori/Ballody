using UnityEngine;
using System.Collections;
using MadLevelManager;
using System.Collections.Generic;

public class CompleteChecker : MonoBehaviour {

	List<string> property = new List<string>();
	public string[] levelNameFlag;
	public GameObject[] landMark, showLandMarkBtn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckCompletedMap ();
		property = MadLevelProfile.GetLevelPropertyNames ("Level 1");
		foreach (var properti in property) {
			//Debug.Log (properti);
		}
	}

	void CheckCompletedMap()
	{
		for (int i = 0; i < levelNameFlag.Length; i++) {
			if (MadLevelProfile.IsCompleted (levelNameFlag [i])) {
				landMark [i].SetActive (true);
			}
		}
	}
}
