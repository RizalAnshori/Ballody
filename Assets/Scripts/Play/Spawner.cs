using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject Block;
	public Sprite bonusSprite;
    public Transform[] spawnPos;
	public List<GameObject> pooledObj;

	public static Spawner SharedInstance;

	public float speed;
	public bool isTutorial;
	public bool isStopSpawn;
	public bool isBonusStage;
//	public string crown;
	public int amountToPool;
	public int totalBlock;
	public int bonusBlock;

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
		bonusBlock = 0;
        speed = ResourceManager.resourceManager.levelDataBase.levelDatas[GetComponent<GameManager>().dataIndex].levelSpeed;
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
		Debug.Log ("Spawner's OnGameOver");
    }

	void Finished()
	{
		isTutorial = false;
		SpawnActive ();
		Debug.Log ("Finished");
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

	public void SpawnBonus()
	{
		Debug.Log ("Spawn Bonus Called");
		if (bonusBlock <= 20) {
			GameObject blok = GetPooledObject ();
			if (blok != null) {
				blok.transform.position = new Vector3 (spawnPos [Random.Range (0, spawnPos.Length - 1)].transform.position.x, 5.7f, 0);
				blok.GetComponent<SpriteRenderer> ().sprite = bonusSprite;
				blok.SetActive (true);
			} else if (blok == null) {
				GameObject objPlus = (GameObject)Instantiate (Block);
				objPlus.transform.position = new Vector3 (spawnPos [Random.Range (0, spawnPos.Length - 1)].transform.position.x, 5.7f, 0);
				objPlus.GetComponent<SpriteRenderer> ().sprite = bonusSprite;
				pooledObj.Add (objPlus);
			}
			bonusBlock++;
		} 

	}
}
