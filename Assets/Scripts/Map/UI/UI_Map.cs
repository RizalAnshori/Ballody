﻿using System;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Map : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        public GameObject mapsWindow;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            
            mapsWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            mapsWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            button.onClick.AddListener(() => {
                if (mapsWindow.activeSelf)
                {
                    mapsWindow.SetActive(false);
                }
                else
                {
                    parent.GoToState(parent.stateMap);
                }
            });
        }
    }
}
