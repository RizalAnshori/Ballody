using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MadLevelManager;

public class CompleteUI : MonoBehaviour {

	string ballodyName;
    AudioSource audioSource;
	public GameObject completeCanvas;
	public GameObject winPanel;
	public GameObject failPanel;
	public Image crownImg;
	public Sprite[] crownSprite;
	public Text[] scoreText;
	public Text coinText;
	public Text diamondText;
	public Text energyText;
	public Text ballodyNameText;

	void OnEnable()
	{
		EventManager.OnCrownResultE += OnResultCrown;
	}

	void OnDisable()
	{
		EventManager.OnCrownResultE -= OnResultCrown;
	}

	// Use this for initialization
	void Start () {
        ballodyName = ResourceManager.resourceManager.levelDataBase.levelDatas[GetComponent<GameManager>().dataIndex].ballodyName;
        audioSource = GetComponent<AudioSource>();
        completeCanvas.SetActive (false);
	}
	
	void OnResultCrown(string crown)
	{
		completeCanvas.SetActive (true);
		if(crown == "Missed"){
            audioSource.clip = ResourceManager.resourceManager.levelDataBase.failBgm;
            audioSource.Play();
            failPanel.SetActive (true);
			winPanel.SetActive (false);
			scoreText [1].text = GameManager.score.ToString ();
		}
		else if (crown != "Miss") {
            audioSource.clip = ResourceManager.resourceManager.levelDataBase.successBgm;
            audioSource.Play();
			failPanel.SetActive (false);
			winPanel.SetActive (true);
			scoreText [0].text = GameManager.score.ToString ();
			ballodyNameText.text = ballodyName.ToUpper();
			if (crown == "Bronze") {
				crownImg.sprite = crownSprite [0];
				coinText.text = (ResourceManager.resourceManager.bonus*1 + 50).ToString();
				diamondText.text = "0";
				energyText.text = "0";
			} else if (crown == "Silver") {
				crownImg.sprite = crownSprite [1];
				coinText.text = (ResourceManager.resourceManager.bonus*3 + 100).ToString();
				diamondText.text = "1";
				energyText.text = "0";
			} else if (crown == "Gold") {
				crownImg.sprite = crownSprite [2];
				coinText.text = (ResourceManager.resourceManager.bonus*5 + 200).ToString();
				diamondText.text = "3";
				energyText.text = "1";
			} 
		}
		Debug.Log (crown);
	}

	public void Close()
	{
		MadLevel.LoadLevelByName ("Level Select");
	}

	public void Next()
	{
		MadLevel.LoadNext ();
	}

	public void Retry()
	{
		MadLevel.ReloadCurrent ();
	}
}
