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

    [MenuItem("LazirX/Create Subtitle")]
    public static void CreateSubtitle()
    {
        SubtitleData asset = ScriptableObject.CreateInstance<SubtitleData>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/SubtitleDatabase/NewSubtitleData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
