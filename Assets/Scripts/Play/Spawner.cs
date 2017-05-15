using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject Block;
    public Transform[] spawnPos;
    public float speed;
	public bool isTutorial;
	public bool isStopSpawn;

    public static Spawner SharedInstance;
    public List<GameObject> pooledObj;
    public int amountToPool;

	public int totalBlock;

    void OnEnable()
    {
        EventManager.OnGameOverE += OnGameOver;
    }

    void OnDisable()
    {
        EventManager.OnGameOverE -= OnGameOver;
    }

    void Awake()
    {
        SharedInstance = this;
    }

	// Use this for initialization
	void Start () {
        //Spawn();
		isTutorial = true;
        Initiate();
        //SpawnActive();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Initiate()
    {
        pooledObj = new List<GameObject>();
        for(int i = 0; i<amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(Block);
            obj.SetActive(false);
            pooledObj.Add(obj);
        }
    }

	void OnGameOver(bool isMiss)
    {
        speed = 0;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObj.Count - 1; i++)
        {
            if (!pooledObj[i].activeInHierarchy)
            {
                return pooledObj[i];
            }
        }
        return null;
    }

	void Finished()
	{
		isTutorial = false;
		SpawnActive ();
		Debug.Log ("Finished");
	}

    public void SpawnActive()
    {
		if (!isStopSpawn) {
			GameObject blok = GetPooledObject ();
			if (blok != null) {
				blok.transform.position = new Vector3 (spawnPos [Random.Range (0, spawnPos.Length - 1)].transform.position.x, 5.7f, 0);
				blok.SetActive (true);
			} else if (blok == null) {
				GameObject objPlus = (GameObject)Instantiate (Block);
				objPlus.transform.position = new Vector3 (spawnPos [Random.Range (0, spawnPos.Length - 1)].transform.position.x, 5.7f, 0);
				pooledObj.Add (objPlus);
			}
			totalBlock += 1;
		} else {
			Debug.Log (isTutorial);
		}
    }
}
