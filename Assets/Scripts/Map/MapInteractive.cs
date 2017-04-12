using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UniRx;

public class MapInteractive : MonoBehaviour {

    public float distance;
    Vector3 sPos, lPos;

    public Animator anim;
    public GameObject[] triggerHide;
    
    public int mapIndex;
    public float speed;
    public Transform[] map;
    public GameObject cam;

    const string isFirstPlayString = "firstPlay";
    bool isFirstPlay;

    public delegate void SwipeEvent(int map);
    public static event SwipeEvent swipe;

    // Use this for initialization
    void Start () {
        distance = Screen.height * 15 / 100;
        mapIndex = 0;
        StartCoroutine("MoveTo");
        swipe(mapIndex);
    }

    // Update is called once per frame
    void Update () {
        Swipe();
        StartCoroutine("MoveTo");
        AnimControl();

        #if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.A))
        {
            mapIndex--;
            swipe(mapIndex);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            mapIndex++;
            swipe(mapIndex);
        }
    #endif

    }

    

    IEnumerator MoveTo()
    {
        if(!triggerHide[0].active && !triggerHide[1].active)
        {
            yield return new WaitForSeconds(0.5f);
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(map[mapIndex].position.x, map[mapIndex].position.y, cam.transform.position.z), speed * Time.deltaTime);
        }
        yield return new WaitForSeconds(0.5f);
    }

    public void AnimControl()
    {
        if (cam.transform.position.x == map[mapIndex].position.x)
        {
            anim.Play("show");
        }
        else if (cam.transform.position.x != map[mapIndex].position.x)
        {
            anim.Play("hide");
        }
    }

    void Swipe()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                sPos = touch.position;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                lPos = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                lPos = touch.position;
                if (Mathf.Abs(lPos.x - sPos.x) > distance || Mathf.Abs(lPos.y - sPos.y) > distance)
                {
                    if (Mathf.Abs(lPos.x - sPos.x)>Mathf.Abs(lPos.y - sPos.y))
                    {
                        if(lPos.x > sPos.x)//swipe Right
                        {
                            if(mapIndex > 0)
                            {
                                mapIndex--;
                            }
                        }
                        else
                        {
                            if(mapIndex < map.Length)
                            {
                                mapIndex++;
                            }
                        }
                        swipe(mapIndex);
                    }
                }
            }
        }
    }
}
