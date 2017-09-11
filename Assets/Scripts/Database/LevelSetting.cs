using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class LevelData
{
    public string ballodyName;
    public int levelSpeed;
    public string levelPlayerPrefs;
    public AudioClip levelAudio;
}

public class LevelSetting : ScriptableObject {

    const string levelSettingAssetName = "LevelSettingDatabase";
    const string levelSettingPath = "Resources";
    const string levelStringExtension = ".asset";

    public static LevelSetting _instance;

    static LevelSetting Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = Resources.Load(levelSettingAssetName) as LevelSetting;

                if (_instance == null)
                {
                    _instance = CreateInstance<LevelSetting>();

                    #if UNITY_EDITOR
                    string properPath = Path.Combine(Application.dataPath, levelSettingPath);
                    if (!Directory.Exists(properPath))
                    {
                        AssetDatabase.CreateFolder("Assets", "Pixelesthe Configuration");
                        AssetDatabase.CreateFolder("Assets/Pixelesthe Configuration", "Resources");
                    }

                    string fullPath = Path.Combine(Path.Combine("Assets", levelSettingPath), levelSettingAssetName + levelStringExtension);
                    AssetDatabase.CreateAsset(_instance, fullPath);
                    #endif
                }
            }
            return _instance;
        }
    }

    #if UNITY_EDITOR
    [MenuItem("Tools/Level Database Setting", false, 1)]
    public static void EditSetting()
    {
        Selection.activeObject = Instance;
        EditorApplication.ExecuteMenuItem("Window/Inspector");
    }
#endif

    [SerializeField]
    public List<LevelData> levelDatas = new List<LevelData>();
}
