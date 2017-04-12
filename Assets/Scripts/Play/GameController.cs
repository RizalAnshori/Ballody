using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject[] tapButton;
    public string[] nameTag;

    //make event and delegate and pass codename of every TapButton
    public delegate void Tap(string id);
    public static event Tap OnTap;

    public delegate void Release();
    public static event Release OnRelease;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Raycaster();
    }

    void Raycaster()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        if(Input.GetMouseButtonDown(0))
        {
            if(hit.collider != null)
            {
                if(hit.collider.gameObject == tapButton[0])
                {
                    OnTap(nameTag[0]);
                }
                if (hit.collider.gameObject == tapButton[1])
                {
                    OnTap(nameTag[1]);
                }
                if (hit.collider.gameObject == tapButton[2])
                {
                    OnTap(nameTag[2]);
                }
                if (hit.collider.gameObject == tapButton[3])
                {
                    OnTap(nameTag[3]);
                }
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            OnRelease();
        }
    }
}