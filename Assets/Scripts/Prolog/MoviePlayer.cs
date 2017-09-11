using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MoviePlayer : MonoBehaviour {

    public MovieTexture movie;
    private AudioSource audioSource;

    public GameObject button;

	// Use this for initialization
	void Start () {
        Init();
	}
	
    void Init()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        //GetComponent<RawImage>().SetNativeSize();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = movie.audioClip;

        movie.Play();
        audioSource.Play();
    }

    void Update()
    {
        if(movie.isPlaying)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }
}
