using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Map : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;
        
        public GameObject mapsWindow;
        
        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            mapsWindow.transform.DOScale(1, 0.3f).OnPlay(() => { mapsWindow.SetActive(true); });
            mapsWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            mapsWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { mapsWindow.SetActive(false); });
            mapsWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            mapsWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            button.onClick.AddListener(() => {
                if (mapsWindow.activeSelf)
                {
                    parent.GoToState(parent.stateIdle);
                }
                else
                {
                    parent.GoToState(parent.stateMap);
                }
            });
        }
    }
}
