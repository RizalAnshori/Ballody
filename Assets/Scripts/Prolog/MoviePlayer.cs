using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MoviePlayer : MonoBehaviour {

#if UNITY_EDITOR
    public MovieTexture movie;
#endif
    private AudioSource audioSource;

    public GameObject button;

	// Use this for initialization
	void Start () {
        Init();
	}
	
    void Init()
    {
#if UNITY_ANDROID
        Handheld.PlayFullScreenMovie("XiaoYing_Video_1495228230424");
#else
        GetComponent<RawImage>().texture = movie as MovieTexture;
        movie.Play();
        //GetComponent<RawImage>().SetNativeSize();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = movie.audioClip;        
        audioSource.Play();
#endif

    }

    void Update()
    {
#if UNITY_EDITOR
        if(movie.isPlaying)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
#endif

        if (Input.GetMouseButton(0))
        {
            Application.LoadLevel("Level Select  Edited");
        }
    }
}
