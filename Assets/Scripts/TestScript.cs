using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScript : MonoBehaviour {

	public GameObject cameraObj;
	public static TestScript instance;


	public GameObject tesTransform;

    public Button buttonTest;
	// Use this for initialization
	void Start () {
		instance = this;
        buttonTest.onClick.AddListener(() => { ClickTest(); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void move()
	{
		cameraObj.transform.position = Vector2.MoveTowards(cameraObj.transform.position,tesTransform.transform.position,1f);
		Debug.Log ("It's Called");
	}

    public void ClickTest()
    {
        Debug.Log("Clicked");
    }
}
