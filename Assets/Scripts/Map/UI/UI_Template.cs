using System;
using Bedivere.FSM;
using UnityEngine;

namespace KartuMuslim
{
    public class UI_Template : MonoBehaviour, IBFSMState
    {
        [HideInInspector] public UIManager parent;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
        }

        public void OnExit(TransitionCause cause)
        {
        }
    }
}

