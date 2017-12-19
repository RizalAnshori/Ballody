using System;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_PromptExit : MonoBehaviour, IBFSMState
    {
        [HideInInspector] public UIManager parent;

        [SerializeField] GameObject exitWindow;

        [SerializeField] Button yesButton;
        [SerializeField] Button noButton;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            exitWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            exitWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            yesButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });

            noButton.onClick.AddListener(() =>
            {
                parent.GoToState(parent.stateIdle);
            });
        }
    }
}

