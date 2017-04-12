using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public GameObject[] levelStone;
    public GameObject[] levelName;
    public GameObject[] emptyField;

    public int levelUnlocked;
    public int map, a;
    const string levelPrefs = "levelPrefs";

    void Awake()
    {
        //PlayerPrefs.SetInt(levelPrefs,1);
        levelUnlocked = PlayerPrefs.GetInt(levelPrefs);
        if (levelUnlocked <= 0)
        {
            levelUnlocked = 1;
        }
        PlayerPrefs.SetInt(levelPrefs, 3);

    }

    // Use this for initialization
    void Start () {
        //LevelCheck(map);
	}

    void OnEnable()
    {
        MapInteractive.swipe += LevelCheck;
    }

    void OnDisable()
    {
        MapInteractive.swipe -= LevelCheck;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoToScene(int sceneNumber)
    {
        sceneNumber += map;
        SceneManager.LoadScene("Game " + sceneNumber);
    }

    public void ResetMap()
    {
        for(int i = 0; i< 3; i++)
        {
            emptyField[i].SetActive(true);
            levelStone[i].SetActive(false);
            levelName[i].SetActive(false);
        }
    }

    public IEnumerator LevelCheckImpl()
    {
        map = a * 3;
        Debug.Log("from Level Script : " + map);
        yield return new WaitForSeconds(0.1f);
        for (int i = 0 + map; i < levelUnlocked; i++)
        {
            Debug.Log(i);
            emptyField[i].SetActive(false);
            levelStone[i].SetActive(true);
            levelName[i].SetActive(true);
        }
        Debug.Log("Level Cek Called ");
    }

    public void LevelCheck(int alpha)
    {
        //ResetMap();
        a = alpha;
        StartCoroutine("LevelCheckImpl");
    }
}
