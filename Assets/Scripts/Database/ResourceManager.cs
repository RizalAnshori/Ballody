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
	string JSONName = "resourceJson";
	string jSONPath = "Assets/Resources/ResourceJSON.json";
	public int bonus;
	public int blockHit;

	void OnEnable()
	{
		Load ();
	}

	void OnDisable()
	{
		SaveData();
	}

	void Awake()
	{
		
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

	}
	
	// Update is called once per frame
	void Update () {

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
		}
	}

	public void AddResources(int crownInit, int crownValue, string crownPrefs)
	{
		if (crownInit < crownValue) {
			if (crownValue == 1) {
				PlayerPrefs.SetInt (crownPrefs, 1);
				resource.coin = 50;
				resource.diamond = 0;
				resource.energy = 0;
			} else if (crownValue == 2) {
				PlayerPrefs.SetInt (crownPrefs, 2);
				resource.coin = 100;
				resource.diamond = 1;
				resource.energy = 0;
			} else if (crownValue == 3) {
				PlayerPrefs.SetInt (crownPrefs, 3);
				resource.coin = 200;
				resource.diamond = 3;
				resource.energy = 1;
			}
		} else {
			Debug.Log ("You get Nothing");
		}
	}

	void Load()
	{
		if (File.ReadAllText (jSONPath) != "") {
			string json = File.ReadAllText (jSONPath);
			resource = JsonUtility.FromJson<Resource> (json);
		} else {
			Debug.Log ("Empty");
			resource.coin = 2000;
			resource.diamond = 5;
			resource.energy = 5;
		}
	}

	void SaveData()
	{
		string json = JsonUtility.ToJson (resource);
		Debug.Log (json);
		StreamWriter sw = File.CreateText (jSONPath);
		sw.Close ();

		File.WriteAllText (jSONPath, json);
		Debug.Log ("Saved");
	}
}