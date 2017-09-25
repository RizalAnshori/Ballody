using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void GameOver(bool isMiss);
    public static event GameOver OnGameOverE;

	public delegate void CalcResult(string score);
    public static event CalcResult OnCalcResultE;

	public delegate void CrownResult(string Crown);
	public static event CrownResult OnCrownResultE;

    public delegate void MapUnlocked(string id);
    public static event MapUnlocked OnMapUnlockedE;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void OnGameOver(bool isMiss)
    {
        if(OnGameOverE != null)
        {
			OnGameOverE(isMiss);
        }
    }

	public static void OnCalcResult(string score)
    {
        if(OnCalcResultE != null)
        {
            OnCalcResultE(score);
        }
    }

	public static void OnCrownResult(string crown)
	{
		if (OnCrownResultE != null) {
			OnCrownResultE (crown);
		}
	}

    public static void OnMapUnlocked(string landMarkID)
    {
        if(OnMapUnlockedE!=null)
        {
            OnMapUnlockedE(landMarkID);
            Debug.Log("Complete Broadcaster Called with Id" + landMarkID);
        }
    }
}
