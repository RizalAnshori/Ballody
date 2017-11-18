using System;
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
            shopWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            shopWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            button.onClick.AddListener(() => {
                if (shopWindow.activeSelf)
                {
                    shopWindow.SetActive(false);
                }
                else
                {
                    parent.GoToState(parent.stateShop);
                }
            });
        }
    }
}