using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Shop : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        public GameObject shopWindow;
        
        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            shopWindow.transform.DOScale(1, 0.3f).OnPlay(() => { shopWindow.SetActive(true); });
            //shopWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            shopWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { shopWindow.SetActive(false); });
            //shopWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            shopWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            button.onClick.AddListener(() => {
                if (shopWindow.activeSelf)
                {
                    parent.GoToState(parent.stateIdle);
                }
                else
                {
                    parent.GoToState(parent.stateShop);
                }
            });
        }
    }
}