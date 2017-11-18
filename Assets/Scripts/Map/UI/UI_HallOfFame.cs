using System;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_HallOfFame : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        public GameObject hallOfFameWindow;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            hallOfFameWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            hallOfFameWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            button.onClick.AddListener(() => {
                if (hallOfFameWindow.activeSelf)
                {
                    hallOfFameWindow.SetActive(false);
                }
                else
                {
                    parent.GoToState(parent.stateHallOfFame);
                }
            });
        }
    }
}
