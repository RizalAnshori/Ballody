using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_ChangeLanguage : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        [SerializeField] GameObject settingWindow;
        [SerializeField] GameObject changeLanguageWindow;

        [Space]
        public Button englishBtn;
        public Button indonesiaBtn;
        public Button javaneseBtn;
        public Button balineseBtn;
        
        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            settingWindow.SetActive(true);
            changeLanguageWindow.transform.DOScale(1, 0.3f).OnPlay(() => { changeLanguageWindow.SetActive(true); parent.PlaySFX(); });
            //changeLanguageWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            changeLanguageWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { changeLanguageWindow.SetActive(false); });
            //changeLanguageWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            changeLanguageWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            englishBtn.onClick.AddListener(() => {
                //add function
                OnButtonClicked(0);
            });

            balineseBtn.onClick.AddListener(() => {
                //add function
                OnButtonClicked(1);
            });

            indonesiaBtn.onClick.AddListener(() => {
                //add function
                OnButtonClicked(2);
            });

            javaneseBtn.onClick.AddListener(() => {
                //add function
                OnButtonClicked(3);
            });

        }

        void OnButtonClicked(int id)
        {
            Debug.Log("Change Button");
            parent.stateSetting.ChangeBackground(id);
            parent.GoToState(parent.stateSetting);

        }
    }
}
