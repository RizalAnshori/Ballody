using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Use for score and highscore
	public static int score;
	public int highScore;
    public string playerPrefsID;
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
		score = 0;
        highScore = PlayerPrefs.GetInt(playerPrefsID);
        startingTime = audioClip.length;
		StartCoroutine ("PlayAudio");
        //audioSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update () {
        CheckHighScore();
        textScore.text = score.ToString();
        Timer();
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

	IEnumerator PlayAudio()
	{
		yield return new WaitForSeconds (5);
		audioSource.PlayOneShot(audioClip);
	}

    void Timer()
    {
		if (!spawnerScript.isTutorial) {
			spawnerScript.isStopSpawn = isFinishedCheck ();
			timerSlider.value += (timerSlider.maxValue/startingTime)*Time.deltaTime;
		}
		if (timerSlider.value >= 1) {
			EventManager.OnGameOver (false);
		}
    }

	bool isFinishedCheck()
	{
		if (timerSlider.value > timerSlider.maxValue-(timerSlider.maxValue/startingTime)*5) {
			return true;
		} else {
			return false;
		}
	}

	void OnGameOver(bool isMissed)
    {
		CheckRank (isMissed);
		audioSource.Stop ();
    }

	void CheckRank(bool isMiss)
	{
		string crown;
		if (!isMiss) {
			persentase = ((float)perfect / (float)spawnerScript.totalBlock) * 100;
			if (persentase <= 40) {
				crown = "Bronze";
			} else if (persentase >= 80) {
				crown = "Gold";
			} else {
				crown = "Silver";
			}
		} else {
			crown = "Missed";
		}
		Debug.Log (crown);
//		EventManager.OnCalcResult (crown); //Calling Complete UI
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
