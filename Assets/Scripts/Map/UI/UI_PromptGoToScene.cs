using System;

using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;
using MadLevelManager;

namespace Ballody
{
    public class UI_PromptGoToScene : MonoBehaviour, IBFSMState
    {
        [HideInInspector] public UIManager parent;

        public GameObject goToSceneWindow;

        public Button yesButton;
        public Button noButton;

        private string levelName;

        void OnEnable()
        {
            EventManager.OnLevelIconClickedE += OnLevelIconClicked;
        }


        void OnDisable()
        {
            EventManager.OnLevelIconClickedE -= OnLevelIconClicked;
        }

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            goToSceneWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            goToSceneWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            yesButton.onClick.AddListener(() => {
                MadLevel.LoadLevelByName(levelName);
            });

            noButton.onClick.AddListener(() =>
            {
                parent.GoToState(parent.stateIdle);
            });
        }

        private void OnLevelIconClicked(string _levelName)
        {
            levelName = _levelName;
            InitButton(null);
            parent.GoToState(parent.stateGoToScene);
        }
    }
}

