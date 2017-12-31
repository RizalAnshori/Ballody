using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button mapsButton;
    [SerializeField] Button quitButton;
    [SerializeField] GameObject pauseWindow;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame

    void Init()
    {
        audioSource = FindObjectOfType<AudioSource>();
        Time.timeScale = 1;
        pauseButton.onClick.AddListener(() => { Pause(); });
        resumeButton.onClick.AddListener(() => { StartCoroutine(Resume()); });
        restartButton.onClick.AddListener(() => { Restart(); });
        mapsButton.onClick.AddListener(() => { Maps(); });
        quitButton.onClick.AddListener(() => { Quit(); });
    }

    void Pause()
    {
        Debug.Log("Pause Called");
        pauseWindow.SetActive(true);
        audioSource.Pause();
        Time.timeScale = 0;
    }

    IEnumerator Resume()
    {
        pauseWindow.SetActive(false);
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        audioSource.UnPause();
    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void Maps()
    {
        Application.LoadLevel(1);
    }

    void Quit()
    {
        Application.Quit();
    }
}
