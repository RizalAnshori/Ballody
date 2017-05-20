using UnityEngine;
using System.Collections;

public class BlockBehavior : MonoBehaviour {

    public bool isDone;
    Spawner spawner;

    void Awake()
    {
        spawner = GameObject.Find("Manager").GetComponent<Spawner>();
        isDone = false;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.down*spawner.speed*Time.deltaTime;
        NormalBehave();
	}

    void NormalBehave()
    {
        //pos 4.5
        if (this.transform.position.y <= 4 && !isDone)
        {
			if (spawner.isBonusStage) {
				spawner.SpawnBonus ();
			} else {
				spawner.SpawnActive();
			}
            isDone = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.tag == "Death Line")
        {
			if (!spawner.isBonusStage) {
				//EventManager.OnGameOver (true);
				this.gameObject.SetActive (false);
			} else {
				this.gameObject.SetActive (false);
				ResourceManager.resourceManager.blockHit += 1;
			}
        }
    }

    void OnBecameInvisible()
    {
        isDone = false;
        this.gameObject.SetActive(false);
    }
}


