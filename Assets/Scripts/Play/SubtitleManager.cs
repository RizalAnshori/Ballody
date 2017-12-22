using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubtitleManager : MonoBehaviour {

    public Image subtitleImage;

    AudioSource audioSource;
    SubtitleData subtitleData;
    public float triggerTime;
    public int index = 0;

    void OnEnable()
    {
        audioSource = GameObject.FindObjectOfType<AudioSource>();
    }

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        if(subtitleData != null)
        {
            SubtitleSetter();
        }
	}

    void Init()
    {
        subtitleData = ResourceManager.resourceManager.levelDataBase.levelDatas[GetComponent<GameManager>().dataIndex].subtitle;
        if(subtitleData!=null)
        {
            triggerTime = subtitleData.subtitleDatas[0].triggerTime;
        }
    }

    void SubtitleSetter()
    {
        if (audioSource.isPlaying)
        {
            if (audioSource.time >= triggerTime)
            {
                subtitleImage.gameObject.SetActive(true);
                if(subtitleData.subtitleDatas[index].subtitleSprite != null)
                {
                    subtitleImage.gameObject.SetActive(true);
                    subtitleImage.sprite = subtitleData.subtitleDatas[index].subtitleSprite;
                    subtitleImage.SetNativeSize();
                }
                else
                {
                    subtitleImage.gameObject.SetActive(false);
                }
                if (index < subtitleData.subtitleDatas.Count - 1)
                {
                    index++;
                    triggerTime = subtitleData.subtitleDatas[index].triggerTime;
                }
            }
        }
        else
        {
            subtitleImage.gameObject.SetActive(false);
        }
    }
}
