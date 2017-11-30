using UnityEngine;
using System.Collections;
using MadLevelManager;
using System.Collections.Generic;

[System.Serializable]
public struct CheckPoint
{
    public MadLevelIcon tapIcon;
    public string landMarkId;
    //public GameObject level;
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

    void CheckLandMark()
    {
        for(int i = 0; i<cekPointList.Count; i++)
        {
            //if(cekPointList[i].landMarkId == id)
            //{
            //    //Unlock LandMark
            //    cekPointList[i].landMark.SetActive(true);
            //}
            //else
            //{
            //    //LandMark Not Found
            //    //There is nothing to do
            //}
            if (PlayerPrefs.HasKey(ResourceManager.resourceManager.landMarkDataBase.landMarkList[i]))
            {
                cekPointList[i].tapIcon.guiDepth = 0;
                //cekPointList[i].tapIcon.visible = false;
                //cekPointList[i].tapIcon.gameObject.GetComponentInChildren<MadLevelIcon>().visible = false;
                cekPointList[i].landMark.SetActive(true);
            }
        }
    }
}

///Note
//Make PlayerPrefs to save how many landmark unlocked just for in case if we always check/broadcaster failed to notify
