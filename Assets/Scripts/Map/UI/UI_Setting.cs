using System;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Setting : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        public GameObject settingWindow;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            
            settingWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            settingWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            button.onClick.AddListener(() => {
                if (settingWindow.activeSelf)
                {
                    settingWindow.SetActive(false);
                }
                else
                {
                    parent.GoToState(parent.stateSetting);
                }
            });
        }
    }
}
