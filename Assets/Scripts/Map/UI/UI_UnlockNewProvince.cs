using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_UnlockNewProvince : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;

        public GameObject unlockNewProvinceWindow;
        public Animator anim;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            unlockNewProvinceWindow.SetActive(true);
            anim.Play("appear");

        }

        public void OnExit(TransitionCause cause)
        {
            unlockNewProvinceWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {

        }
    }
}

