using UnityEngine;
using System.Collections;

public class TapBehavior : MonoBehaviour {

    public bool isActivated;
    public string GameObjectId;
    public GameManager GM;
	public Spawner spawnerScript;
    public ParticleSystem[] particleSystemObj;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        GameController.OnTap += Activate;
        GameController.OnRelease += Deactivate;
    }

    void OnDisable()
    {
        GameController.OnTap -= Activate;
        GameController.OnRelease -= Deactivate;
    }

    void Detector(Vector2 pos)
    {
        float deltaPos = (float)this.transform.position.y - pos.y; ;
        //Debug.Log(deltaPos.ToString());
        string status = GM.CalculateScore(deltaPos);
        CallParticle(status);
        //Debug.Log(status);
    }

    void Activate(string id)
    {
        if(GameObjectId == id)
        {
            isActivated = true;
            //Debug.Log(GameObjectId);
        }
    }

    void CallParticle(string status)
    {
        //Debug.Log("Call Particle: " + status);
        if(status == "Perfect")
        {
            particleSystemObj[0].Play();
        }
        else if(status == "Near Perfect")
        {

        }
        else if(status == "Good")
        {
            particleSystemObj[2].Play();
        }
        else if (status == "Bad")
        {
            particleSystemObj[3].Play();
        }
        //particleSystem.startColor = new Color(0,0,0,255);
    }

    void Deactivate()
    {
        isActivated = false;
        //Debug.Log("Release : "+ GameObjectId);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Block" && isActivated)
        {
            Detector(col.transform.position);
            Debug.Log(col.gameObject.name + "hancur");
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
			if (spawnerScript.isBonusStage) {
				GM.audioSource.PlayOneShot (GM.bonusAudioBlock);
				ResourceManager.resourceManager.blockHit += 1;
			}
            Deactivate();
        }
    }
}
