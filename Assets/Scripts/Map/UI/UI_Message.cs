using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Message : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        [SerializeField]
        GameObject messageWindow;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            messageWindow.transform.DOScale(1, 0.3f).OnPlay(() => { messageWindow.SetActive(true); parent.PlaySFX(); });
            //messageWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            messageWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { messageWindow.SetActive(false); });
            //messageWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            messageWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            button.onClick.AddListener(() => {
                if(messageWindow.activeSelf)
                {
                    parent.GoToState(parent.stateIdle);
                }
                else
                {
                    parent.GoToState(parent.stateMessage);
                }
            });
        }
    }
}
