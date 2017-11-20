using System;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_ChangeLanguage : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        public GameObject changeLanguageWindow;

        [Space]
        public Button englishBtn;
        public Button indonesiaBtn;
        public Button javaneseBtn;
        public Button balineseBtn;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            changeLanguageWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            changeLanguageWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            englishBtn.onClick.AddListener(() => {
                //add function
                OnButtonClicked(englishBtn.name);
            });

            indonesiaBtn.onClick.AddListener(() => {
                //add function
                OnButtonClicked(indonesiaBtn.name);
            });

            javaneseBtn.onClick.AddListener(() => {
                //add function
                OnButtonClicked(javaneseBtn.name);
            });

            balineseBtn.onClick.AddListener(() => {
                //add function
                OnButtonClicked(balineseBtn.name);
            });
        }

        void OnButtonClicked(string name)
        {
            Debug.Log("Change Button");
            parent.GoToState(parent.stateSetting);
        }
    }
}
