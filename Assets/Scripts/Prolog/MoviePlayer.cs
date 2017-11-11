using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MoviePlayer : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Init();
	}
	
    void Init()
    {
        Handheld.PlayFullScreenMovie("XiaoYing_Video_1495228230424.mp4",Color.black,FullScreenMovieControlMode.CancelOnInput,FullScreenMovieScalingMode.AspectFill);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Application.LoadLevel("Level Select  Edited");
        }
    }
}
