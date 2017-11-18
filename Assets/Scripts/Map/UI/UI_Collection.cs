using System;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Collection : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        public GameObject collectionWindow;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            collectionWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            collectionWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            button.onClick.AddListener(() => {
                if (collectionWindow.activeSelf)
                {
                    collectionWindow.SetActive(false);
                }
                else
                {
                    parent.GoToState(parent.stateCollection);
                }
            });
        }
    }
}
