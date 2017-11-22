﻿using System;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Idle : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;
        
        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
        }

        public void OnExit(TransitionCause cause)
        {
        }

        public void InitButton(Button button)
        {
            button.onClick.AddListener(() => {
                //add function
            });
        }
    }
}