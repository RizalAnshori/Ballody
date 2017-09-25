using UnityEngine;
using System.Collections;

public class CompletedBrodcaster : MonoBehaviour {

    public string landMarkId;

	// Use this for initialization
	void Start () {
        CekMap();
	}

    public void CekMap()
    {
        EventManager.OnMapUnlocked(landMarkId);
        Debug.Log("Cek Map Called");
    }

    IEnumerator call()
    {
        yield return new WaitForSeconds(1);
        
    }
}
