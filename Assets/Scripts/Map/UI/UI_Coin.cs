using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Coin : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        [SerializeField]
        GameObject coinWindow;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            coinWindow.transform.DOScale(1, 0.3f).OnPlay(() => { coinWindow.SetActive(true); });
            //coinWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            coinWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { coinWindow.SetActive(false); });
            //coinWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            coinWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            button.onClick.AddListener(() => {
                if(coinWindow.activeSelf)
                {
                    parent.GoToState(parent.stateIdle);
                }
                else
                {
                    parent.GoToState(parent.stateCoin);
                }
            });
        }
    }
}
