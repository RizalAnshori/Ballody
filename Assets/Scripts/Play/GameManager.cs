using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int dataIndex;

    //Use for score and highscore
    string playerPrefsID;
	public static int score;
	public int highScore;
	public Text textScore;
	public Text textHighScore;

	//Use for storing block Point
	public Spawner spawnerScript;
	public int good;
	public int perfect;
	public float persentase;

    //Use for Timer Slider Progress
    public Slider timerSlider;
    public float startingTime;

    public Animator anim;

    public AudioSource audioSource;
    public AudioClip audioClip;
	public AudioClip bonusAudioBlock;

	//Use for flag
	bool isBonusCalled = true, isSentRank = true;
	string crown;

    public GameObject bonusSentenceSign;


    void OnEnable()
    {
        EventManager.OnGameOverE += OnGameOver;
    }

    void OnDisable()
    {
        if(highScore < score)
        {
            PlayerPrefs.SetInt(playerPrefsID,score);
        }
        EventManager.OnGameOverE -= OnGameOver;
    }

    // Use this for initialization
    void Start () {
        audioClip = ResourceManager.resourceManager.levelDataBase.levelDatas[dataIndex].levelAudio;
        playerPrefsID = ResourceManager.resourceManager.levelDataBase.levelDatas[dataIndex].levelPlayerPrefs;
        score = 0;
        highScore = PlayerPrefs.GetInt(playerPrefsID);
        startingTime = audioClip.length;
		StartCoroutine (PlayAudio());
        bonusSentenceSign.SetActive(false);
        //timerSlider.maxValue = audioClip.length;
        //audioSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update () {
		textScore.text = score.ToString();
		if (!spawnerScript.isBonusStage) {
			CheckHighScore ();
			Timer ();
		} else {
			isBonusFinished ();
		}
	}

	void isBonusFinished()
	{
		if(ResourceManager.resourceManager.blockHit >= 20) {
            if(isSentRank)
            {
			StartCoroutine (SendRank());
			Debug.Log ("Else If Called");
            }
            isSentRank = false;
		}
	}

    void CheckHighScore()
    {
        if(highScore < score)
        {
            textHighScore.text = score.ToString();
        }
        else
        {
            textHighScore.text = highScore.ToString();
        }
    }


    void Timer()
    {
		if (!spawnerScript.isTutorial) {
			spawnerScript.isStopSpawn = isFinishedCheck ();
            timerSlider.value += (timerSlider.maxValue/startingTime)*Time.deltaTime;
            //timerSlider.value = audioSource.time;
		}
		if (timerSlider.value >= 1) {
			//If Player can finish the map
			//EventManager.OnGameOver (false);
			CheckRank(false);
		}
    }


	void OnGameOver(bool isMissed)
    {
		CheckRank (isMissed);
		audioSource.Stop ();
    }

	void CheckRank(bool isMiss)
	{
		if (!isMiss) {
			persentase = ((float)perfect / (float)spawnerScript.totalBlock) * 100;
			if (persentase <= 40) {
				crown = "Bronze";
			} else if (persentase >= 80) {
				crown = "Gold";
			} else {
				crown = "Silver";
			}
			StartCoroutine (DelayToBonus());
		} else {
			crown = "Missed";
			EventManager.OnCalcResult (crown); //Calling Complete UI
		}
		Debug.Log (crown);
	}

	IEnumerator SendRank()
	{
		yield return new WaitForSeconds (0.5f);
		EventManager.OnCalcResult (crown);
		Debug.Log ("Send Rank Called");
	}

	IEnumerator DelayToBonus()
	{
		yield return new WaitForSeconds (0.1f);
		if (isBonusCalled) {
			isBonusCalled = false;
			spawnerScript.isBonusStage = true;
            if(bonusSentenceSign != null)
            {
                bonusSentenceSign.SetActive(true);
                yield return new WaitForSeconds(1);
                bonusSentenceSign.SetActive(false);
                yield return new WaitForSeconds(1);
            }
            spawnerScript.SpawnBonus ();
//			spawnerScript.crown = crown;
		}
	}

	IEnumerator PlayAudio()
	{
		yield return new WaitForSeconds (5);
        audioSource.clip = audioClip;
        audioSource.loop = false;
        audioSource.Play();
		//audioSource.PlayOneShot(audioClip);
	}

	bool isFinishedCheck()
	{
		if (timerSlider.value > timerSlider.maxValue-(timerSlider.maxValue/startingTime)*5) {
			return true;
		} else {
			return false;
		}
	}

    public string CalculateScore(float pos)
    {
        string status;
        if(pos > -0.4 && pos < 0.4)
        {
            status = "Perfect";
            score += 50;
			perfect += 1;
            anim.Play("Perfect");
            return status;
        }
//        else if ((pos > 0.1 && pos < 0.2) || (pos < -0.1 && pos > -0.2))
//        {
//            status = "Near Perfect";
//            score += Random.Range(70, 90);
//            return status;
//        }
        else if ((pos > 0.4 && pos < 0.9) || (pos < -0.4 && pos > -0.9))
        {
            status = "Good";
			score += 30;
			good += 1;
            anim.Play("Good");
            return status;
        }
//        else if((pos > 0.5 && pos < 0.9) || (pos < -0.5 && pos > -0.9))
//        {
//            status = "Bad";
//            score += Random.Range(20, 50);
//            return status;
//        }
        else
        {
            anim.Play("Miss");
            Debug.Log("Miss");
        }
        return null;
    }
}
