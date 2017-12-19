using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void GameOver(bool isMiss);
    public static event GameOver OnGameOverE;

	public delegate void CalcResult(string score);
    public static event CalcResult OnCalcResultE;

	public delegate void CrownResult(string Crown);
	public static event CrownResult OnCrownResultE;

    public delegate void MapUnlocked();
    public static event MapUnlocked OnMapUnlockedE;

    public delegate void LevelIconClicked(string levelName);
    public static event LevelIconClicked OnLevelIconClickedE;

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
            OnMapUnlockedE();
            Debug.Log("Complete Broadcaster Called with Id" + landMarkID);
        }
    }
    
    public static void OnLevelIconClicked(string levelName)
    {
        if(OnLevelIconClickedE!=null)
        {
            OnLevelIconClickedE(levelName);
        }
    }
}
