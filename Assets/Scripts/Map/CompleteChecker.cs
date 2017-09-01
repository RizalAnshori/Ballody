using UnityEngine;
using System.Collections;
using MadLevelManager;
using System.Collections.Generic;

[System.Serializable]
public struct CheckPoint
{
    public string landMarkId;
    public GameObject level;
    public GameObject landMark;
}

public class CompleteChecker : MonoBehaviour {

    public List<CheckPoint> cekPointList;

    void OnEnable()
    {
        EventManager.OnMapUnlockedE += CheckLandMark;
    }

    void OnDisable()
    {
        EventManager.OnMapUnlockedE -= CheckLandMark;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CheckLandMark(string id)
    {
        for(int i = 0; i<cekPointList.Count; i++)
        {
            if(cekPointList[i].landMarkId == id)
            {
                //Unlock LandMark
                cekPointList[i].landMark.SetActive(true);
            }
            else
            {
                //LandMark Not Found
                //There is nothing to do
            }
        }
    }
}

///Note
//Make PlayerPrefs to save how many landmark unlocked just for in case if we always check/broadcaster failed to notify
