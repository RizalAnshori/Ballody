using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Use for score and highscore
    public int score, highScore;
    public Text textScore,textHighScore;

    //Use for Timer Slider Progress
    public Slider timerSlider;
    public float startingTime;

    public Animator anim;

    void OnEnable()
    {
    }

    void OnDisable()
    {
        if(highScore < score)
        {
            PlayerPrefs.SetInt("HighScore",score);
        }
    }

    // Use this for initialization
    void Start () {
        highScore = PlayerPrefs.GetInt("HighScore");
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

    void Timer()
    {
        timerSlider.value -= (timerSlider.maxValue/startingTime)*Time.deltaTime;
    }

    public string CalculateScore(float pos)
    {
        string status;
        if(pos > -0.1 && pos < 0.1)
        {
            status = "Perfect";
            score += Random.Range(90,100);
            anim.Play("Perfect");
            return status;
        }
        else if ((pos > 0.1 && pos < 0.2) || (pos < -0.1 && pos > -0.2))
        {
            status = "Near Perfect";
            score += Random.Range(70, 90);
            return status;
        }
        else if ((pos > 0.2 && pos < 0.5) || (pos < -0.2 && pos > -0.5))
        {
            status = "Good";
            score += Random.Range(50, 70);
            anim.Play("Good");
            return status;
        }
        else if((pos > 0.5 && pos < 0.9) || (pos < -0.5 && pos > -0.9))
        {
            status = "Bad";
            score += Random.Range(20, 50);
            return status;
        }
        else
        {
            anim.Play("Miss");
            Debug.Log("Miss");
        }
        return null;
    }

}
