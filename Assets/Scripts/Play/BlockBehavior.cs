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
            //spawner.Spawn();
            spawner.SpawnActive();
            isDone = true;
        }
        //if (isHit)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    void OnBecameInvisible()
    {
        //if (!isHit)
        //{
        //    GM.isGameOver = true;
        //}
        //else
        //{
        //Destroy(this.gameObject);
        isDone = false;
        this.gameObject.SetActive(false);
        //}
    }
}


