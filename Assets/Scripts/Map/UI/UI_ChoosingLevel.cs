using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_ChoosingLevel : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        [SerializeField]
        GameObject chooseLevelWindow;
        [SerializeField]
        GameObject contentLevelWindow;
        [SerializeField]
        GameObject reminderLevelWindow;

        [SerializeField]
        Button closeButton;
        [SerializeField]
        Button sumBarButton;
        [SerializeField]
        Button yogyakartaButton;
        [SerializeField]
        Button NTBButton;

        private string playerPrefsPhrase = "choosingLevel";

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            if (PlayerPrefs.HasKey(playerPrefsPhrase))
            {
                parent.GoToState(parent.stateIdle);
            }
            else
            {
                chooseLevelWindow.SetActive(true);
                contentLevelWindow.transform.DOScale(1, 0.3f).OnPlay(() => { contentLevelWindow.SetActive(true);}).SetDelay(1f);
                PlayerPrefs.SetString(playerPrefsPhrase, playerPrefsPhrase);
            }
        }

        public void OnExit(TransitionCause cause)
        {
            chooseLevelWindow.SetActive(false);
            contentLevelWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { contentLevelWindow.SetActive(false); });
        }

        public void InitButton(Button button)
        {
            contentLevelWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            //button.onClick.AddListener(() => {
            //    //add function
            //});

            closeButton.onClick.AddListener(() =>
            {
                parent.GoToState(parent.stateIdle);
            });

            sumBarButton.onClick.AddListener(() =>
            {
                //add function
                //Move to map sumBar
                reminderLevelWindow.SetActive(true);
                contentLevelWindow.SetActive(false);
            });

            yogyakartaButton.onClick.AddListener(() =>
            {
                //add function
                //move to map Yogya
                //parent.GoToState(parent.stateIdle);
                reminderLevelWindow.SetActive(true);
                contentLevelWindow.SetActive(false);
            });

            NTBButton.onClick.AddListener(() =>
            {
                //add function
                //move to map NTB
                //parent.GoToState(parent.stateIdle);
                reminderLevelWindow.SetActive(true);
                contentLevelWindow.SetActive(false);
            });
        }
    }
}

