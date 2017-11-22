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
        public Sprite imageOn;
        public Sprite imageOff;

        [Space]
        public Toggle sfxToggle;
        public Toggle notificationToggle;
        public Button changeLanguageButton;
        public Button loginFBButton;
        public Button creditButton;

        public string Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

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

            sfxToggle.onValueChanged.AddListener((bool isOn) => {
                ChangeToggleImage(isOn, sfxToggle.GetComponentInChildren<Image>());
                NotificationToggle(isOn);
            });

            notificationToggle.onValueChanged.AddListener((bool isOn) => {
                ChangeToggleImage(isOn, notificationToggle.GetComponentInChildren<Image>());
                SfxToggle(isOn);
            });

            changeLanguageButton.onClick.AddListener(() => {
                parent.GoToState(parent.stateChangeLanguage);
            });

            loginFBButton.onClick.AddListener(() => {
                //Add Function
                Login();
            });

            creditButton.onClick.AddListener(() => {
                //Add Function
                Credit();
            });
        }

        void ChangeToggleImage(bool isOn, Image image)
        {
            if(isOn)
            {
                image.sprite = imageOn;
            }
            else
            {
                image.sprite = imageOff;
            }
        }

        void SfxToggle(bool isOn)
        {
            if(isOn)
            {

            }
            else
            {

            }
        }

        void NotificationToggle(bool isOn)
        {
            if (isOn)
            {

            }
            else
            {

            }
        }

        void Login()
        {

        }

        void Credit()
        {

        }
    }
}
