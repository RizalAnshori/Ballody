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
		coinText.text = ResourceManager.resourceManager.resource.coin.ToString ();
		diamondText.text = ResourceManager.resourceManager.resource.diamond.ToString ();
		if (ResourceManager.resourceManager.resource.energy < 5) {
			energyText.text = ResourceManager.resourceManager.resource.energy.ToString ();
		} else {
			energyText.text = "FULL";
            ResourceManager.resourceManager.resource.energy = 5;
		}
	}

	public void Test()
	{
		Debug.Log ("Level");
	}
}