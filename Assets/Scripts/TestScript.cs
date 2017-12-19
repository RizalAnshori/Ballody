using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScript : MonoBehaviour {

	public GameObject cameraObj;
	public static TestScript instance;


	public GameObject tesTransform;

    public Button buttonTest;

    void OnBecameVisible()
    {
        Debug.Log("Visible");
    }

    void OnBecameInvisible()
    {
        Debug.Log("InVisible");
    }

	// Use this for initialization
	void Start () {
        //instance = this;
        //      buttonTest.onClick.AddListener(() => { ClickTest(); });
        //Debug.Log("OnEnable : " + ResourceManager.resourceManager.levelDataBase.levelDatas[0].levelSpeed);
    }
	
	public void move()
	{
		cameraObj.transform.position = Vector2.MoveTowards(cameraObj.transform.position,tesTransform.transform.position,1f);
		Debug.Log ("It's Called");
	}

    public void ClickTest()
    {
        Debug.Log("Clicked");
        Debug.Log("Before : " + ResourceManager.resourceManager.levelDataBase.levelDatas[0].levelSpeed);
        ResourceManager.resourceManager.levelDataBase.levelDatas[0].levelSpeed += 100;
        Debug.Log("After : " + ResourceManager.resourceManager.levelDataBase.levelDatas[0].levelSpeed);
    }

    void OnDisable()
    {
        //Debug.Log("OnDisable : " + ResourceManager.resourceManager.levelDataBase.levelDatas[0].levelSpeed);
    }

    void OnEnable()
    {
        //Debug.Log("OnEnable : " + ResourceManager.resourceManager.levelDataBase.levelDatas[0].levelSpeed);
    }
}
