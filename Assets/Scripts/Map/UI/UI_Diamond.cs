using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Diamond : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;
        [SerializeField]
        GameObject diamondWindow;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            diamondWindow.transform.DOScale(1, 0.3f).OnPlay(() => { diamondWindow.SetActive(true); parent.PlaySFX(); });
            //diamondWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            diamondWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { diamondWindow.SetActive(false); });
            //diamondWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            diamondWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            button.onClick.AddListener(() => {
                //add function
                if(diamondWindow.activeSelf)
                {
                    parent.GoToState(parent.stateIdle);
                }
                else
                {
                    parent.GoToState(parent.stateDiamond);
                }
            });
        }
    }
}
