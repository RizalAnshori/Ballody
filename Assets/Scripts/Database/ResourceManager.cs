using UnityEngine;
using System;
using System.Collections;
using System.IO;

[Serializable]
public class Resource{
	public int diamond;
	public int energy;
	public int coin;
}

public class ResourceManager : MonoBehaviour {
	public static ResourceManager resourceManager = null;
	public Resource resource = new Resource();
    public LevelSetting levelDataBase;
	string JSONName = "resourceJson";
	string jSONPathOri = "Assets/Resources/ResourceJSON.json";
	string JSONPathNew;
	public int bonus;
	public int blockHit;

    DateTime currentTime;
    DateTime oldTime;
    string timePlayerPrefs = "TimeElapsed";

	void OnEnable()
	{
	}

	void OnDisable()
	{
		SaveData();
	}

	void OnApplicationQuit()
	{
		SaveData();
	}

	void Awake()
	{
		JSONPathNew = Application.persistentDataPath + "/ResourceJSONNew.json";
		//Debug.Log (PlayerPrefs.GetString(JSONName));
		if (resourceManager == null)
			resourceManager = this;
		else if (resourceManager != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		Load ();
	}
	
	public void Add(string resourceName)
	{
		switch (resourceName) {
		case"coin":
			resource.coin += 300;
			break;
		case "diamond":
			resource.diamond += 1;
			break;
		case "energy":
			resource.energy += 1;
			break;
		case "quit":
			Application.Quit ();
			break;
		case "save":
			SaveData ();
			break;
		}
	}

	public void AddResources(int crownInit, int crownValue, string crownPrefs)
	{
		if (crownInit < crownValue) {
			if (crownValue == 1) {
				PlayerPrefs.SetInt (crownPrefs, 1);
				resource.coin += 50;
				resource.diamond += 0;
				resource.energy += 0;
			} else if (crownValue == 2) {
				PlayerPrefs.SetInt (crownPrefs, 2);
				resource.coin += 100;
				resource.diamond += 1;
				resource.energy += 0;
			} else if (crownValue == 3) {
				PlayerPrefs.SetInt (crownPrefs, 3);
				resource.coin += 200;
				resource.diamond += 3;
				resource.energy += 1;
			}
		} else {
			Debug.Log ("You get Nothing");
		}
	}

	void Load()
	{
		string json = "";
        //Debug.Log(JSONPathNew);
		if (File.Exists(JSONPathNew)) {
			json = File.ReadAllText (JSONPathNew);
		} else {
			TextAsset file = Resources.Load ("ResourceJSON") as TextAsset;
			json = file.ToString ();
		}
		resource = JsonUtility.FromJson<Resource> (json);

        //		if (File.ReadAllText (jSONPath) != "") {
        //			string json = File.ReadAllText (jSONPath);
        //			resource = JsonUtility.FromJson<Resource> (json);
        //		} else {
        //			Debug.Log ("Empty");
        //			resource.coin = 2000;
        //			resource.diamond = 5;
        //			resource.energy = 5;
        //		}

        //Loading Time
        currentTime = System.DateTime.Now;
        if (PlayerPrefs.HasKey(timePlayerPrefs))
        {
            long temp = Convert.ToInt64(PlayerPrefs.GetString(timePlayerPrefs));
            oldTime = DateTime.FromBinary(temp);
            TimeSpan difference = currentTime.Subtract(oldTime);
            int multiply = (int)difference.TotalMinutes / 2;
            resource.energy += multiply;

            //Debug.Log("TimeSpan in TotalMinutes : " + difference.TotalMinutes);
        }

		//Debug.Log ("Load Called");
	}

	void SaveData()
	{
		string json = JsonUtility.ToJson (resource);
		Debug.Log (json);

//		string path = Application.persistentDataPath + "/ResourceJSON.json";
//		StreamWriter sw = File.CreateText (path);
//		sw.WriteLine (json);
//		sw.Close ();

		File.WriteAllText(JSONPathNew,json);
		Debug.Log ("Saved");

        //Saving Time
        PlayerPrefs.SetString(timePlayerPrefs, System.DateTime.Now.ToBinary().ToString());
	}
}