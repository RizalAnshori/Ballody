using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceUI : MonoBehaviour {

	public Text coinText;
	public Text diamondText;
	public Text energyText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		coinText.text = ResourceManager.instance.resource.coin.ToString ();
		diamondText.text = ResourceManager.instance.resource.diamond.ToString ();
		if (ResourceManager.instance.resource.energy != 5) {
			energyText.text = ResourceManager.instance.resource.energy.ToString ();
		} else {
			energyText.text = "FULL";
		}


	}

	public void Test()
	{
		Debug.Log ("Level");
	}
}