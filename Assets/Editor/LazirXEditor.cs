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

    [MenuItem("LazirX/Create Landmark Data")]
    public static void CreateLandmarkData()
    {
        LandMarkData asset = ScriptableObject.CreateInstance<LandMarkData>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/NewLandmarkData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("LazirX/Erase PlayerPrefs")]
    public static void ErasePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
