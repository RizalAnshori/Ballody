using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_HallOfFame : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;
        
        public GameObject hallOfFameWindow;
        
        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            hallOfFameWindow.transform.DOScale(1, 0.3f)
                .OnPlay(() => 
                {
                    hallOfFameWindow.SetActive(true);
                    parent.PlaySFX();
                });
            //hallOfFameWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            hallOfFameWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { hallOfFameWindow.SetActive(false); });
            //hallOfFameWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            hallOfFameWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            button.onClick.AddListener(() => {
                if (hallOfFameWindow.activeSelf)
                {
                    parent.GoToState(parent.stateIdle);
                }
                else
                {
                    parent.GoToState(parent.stateHallOfFame);
                }
            });
        }
    }
}
