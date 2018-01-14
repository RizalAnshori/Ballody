using System;
using DG.Tweening;
using Bedivere.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace Ballody
{
    public class UI_Collection : MonoBehaviour, IBFSMState
    {
        [HideInInspector]
        public UIManager parent;
        
        public GameObject collectionWindow;
        
        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            collectionWindow.transform.DOScale(1, 0.3f).OnPlay(() => { collectionWindow.SetActive(true); parent.PlaySFX(); });
            //collectionWindow.SetActive(true);
        }

        public void OnExit(TransitionCause cause)
        {
            collectionWindow.transform.DOScale(0.1f, 0.3f).OnComplete(() => { collectionWindow.SetActive(false); });
            //collectionWindow.SetActive(false);
        }

        public void InitButton(Button button)
        {
            collectionWindow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            button.onClick.AddListener(() => {
                if (collectionWindow.activeSelf)
                {
                    parent.GoToState(parent.stateIdle);
                }
                else
                {
                    parent.GoToState(parent.stateUnlockNewProvince);
                }
            });
        }
    }
}
