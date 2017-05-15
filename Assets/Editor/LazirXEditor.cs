using UnityEngine;
using UnityEditor;
using System.Collections;

public class LazirXEditor : EditorWindow {

	[MenuItem("LazirX/Clear")]
	public static void ClearPlayerPrefs()
	{
		PlayerPrefs.DeleteAll ();
		Debug.Log ("PlayerPrefs Cleared");
	}
}
