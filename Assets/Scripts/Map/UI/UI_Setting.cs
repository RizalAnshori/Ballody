using System;
using DG.Tweening;
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
        public Image settingBackground;
        public Sprite imageOn;
        public Sprite imageOff;

        [Space]
        public Toggle sfxToggle;
        public Toggle notificationToggle;
        public Button changeLanguageButton;
        public Button loginFBButton;
        public Button creditButton;

        [SerializeField]Sprite[] settingSprite;
        
        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            settingWindow.transform.DOScale(1, 0.3f).OnPlay(() => { settingWindow.SetActive(true); parent.PlaySFX(); });
        }

        public void OnExit(TransitionCause cause)
        {
            settingWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { settingWindow.SetActive(false); });
        }

        public void InitButton(Button button)
        {
            settingWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
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

        public void ChangeBackground(int id)
        {
            if(id < settingSprite.Length)
            {
                settingBackground.sprite = settingSprite[id];
            }
            else
            {
                settingBackground.sprite = settingSprite[0];
            }
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
                parent.audioSource.mute = false;
            }
            else
            {
                parent.audioSource.mute = true;
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
            parent.GoToState(parent.stateChoosingLevel);
        }
    }
}
