using UnityEngine;
using System.Collections;
using MadLevelManager;
using System;



public class CompleteManager : MonoBehaviour {
	
	int crownInt;
	public string levelCrown;

    void OnEnable()
    {
        EventManager.OnCalcResultE += OnCalcResultE;
    }

    void OnDisable()
    {
		EventManager.OnCalcResultE -= OnCalcResultE;
    }

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt (levelCrown) != null) {
			crownInt = PlayerPrefs.GetInt (levelCrown);
		} else {
			crownInt = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCalcResultE(string crown)
    {
		if (crown == "Bronze") {
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Playable", false);
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Bronze", true);
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Silver", false);
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Gold", false);
			MadLevelProfile.SetCompleted (MadLevel.currentLevelName,true);
			ResourceManager.resourceManager.AddResources (crownInt, 1, levelCrown);
		} else if (crown == "Silver") {
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Playable", false);
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Bronze", false);
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Silver", true);
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Gold", false);
			MadLevelProfile.SetCompleted (MadLevel.currentLevelName,true);
			ResourceManager.resourceManager.AddResources (crownInt, 2, levelCrown);
		} else if (crown == "Gold") {
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Playable", false);
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Bronze", false);
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Silver", false);
			MadLevelProfile.SetLevelBoolean (MadLevel.currentLevelName, "Gold", true);
			MadLevelProfile.SetCompleted (MadLevel.currentLevelName,true);
			ResourceManager.resourceManager.AddResources (crownInt, 3, levelCrown);
		} else {
			Debug.Log ("Missed");
		}
		EventManager.OnCrownResult (crown);
    }

//	void AddResource(int crownValue)
//	{
//		if (crown < crownValue) {
//			if (crownValue == 1) {
//				PlayerPrefs.SetInt (levelCrown, 1);
//				resourceClass.coin = 50;
//				resourceClass.diamond = 0;
//				resourceClass.energy = 0;
//			} else if (crownValue == 2) {
//				PlayerPrefs.SetInt (levelCrown, 2);
//				resourceClass.coin = 100;
//				resourceClass.diamond = 1;
//				resourceClass.energy = 0;
//			} else if (crownValue == 3) {
//				PlayerPrefs.SetInt (levelCrown, 3);
//				resourceClass.coin = 200;
//				resourceClass.diamond = 3;
//				resourceClass.energy = 1;
//			}
//			jSONAddedResources = JsonUtility.ToJson (resourceClass);
//			PlayerPrefs.SetString (jSONAddedResources,jSONAddedResources);
//		} else {
//			Debug.Log ("You get Nothing");
//		}
//	}
}
