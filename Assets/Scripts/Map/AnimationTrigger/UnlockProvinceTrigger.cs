using UnityEngine;
using System.Collections;
using Ballody;

public class UnlockProvinceTrigger : MonoBehaviour {

    public int landMarkTargetId;
    public UIManager parent;
    //public TargetMapChanger targetMap;

    public void Disable()
    {
        //targetMap.MoveToMap(landMarkTargetId);
        parent.GoToState(parent.stateIdle);
    }

    public void UnlockProvinceEnable()
    {
        parent.GoToState(parent.stateUnlockNewProvince);
    }
}
