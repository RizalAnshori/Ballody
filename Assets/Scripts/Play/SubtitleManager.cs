using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubtitleManager : MonoBehaviour {

    public Image subtitleImage;

    AudioSource audioSource;
    SubtitleData subtitleData;
    float triggerTime;
    int index = 0;

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
        SubtitleSetter();
	}

    void Init()
    {
        subtitleData = ResourceManager.resourceManager.levelDataBase.levelDatas[GetComponent<GameManager>().dataIndex].subtitle;
        triggerTime = subtitleData.subtitleDatas[0].triggerTime;
    }

    void SubtitleSetter()
    {
        if(audioSource.time >= triggerTime)
        {
            //set Trigger Time to be next trigger Time
            //Change Subtitle Sprite
            if(index < subtitleData.subtitleDatas.Count)
            {
            index++;
            triggerTime = subtitleData.subtitleDatas[index].triggerTime;
            subtitleImage.sprite = subtitleData.subtitleDatas[index-1].subtitleSprite;
            }
            else
            {
                subtitleImage.gameObject.SetActive(false);
            }
        }
    }
}
