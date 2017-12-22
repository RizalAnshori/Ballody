using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Energy : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;
        [SerializeField]
        GameObject energyWindow;

        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            energyWindow.transform.DOScale(1, 0.3f).OnPlay(() => { energyWindow.SetActive(true); parent.PlaySFX(); });
            //energyWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            energyWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { energyWindow.SetActive(false); });
            //energyWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            energyWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            button.onClick.AddListener(() => {
                //add function
                if(energyWindow.activeSelf)
                {
                    parent.GoToState(parent.stateIdle);
                }
                else
                {
                    parent.GoToState(parent.stateEnergy);
                }
            });
        }
    }
}