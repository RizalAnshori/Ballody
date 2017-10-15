using UnityEngine;
using System.Collections;
using MadLevelManager;

public class SnapObject : MonoBehaviour {
    public MadFreeDraggable madFreeDraggableIcon;
    public MadFreeDraggable madFreeDraggableMap;

    public int i;
    public Vector3[] centerPos, extentSize;

    public void ChangeSize()
    {
        madFreeDraggableIcon.dragBounds.center = centerPos[i];
        madFreeDraggableIcon.dragBounds.extents = extentSize[i];
        madFreeDraggableMap.dragBounds.center = centerPos[i];
        madFreeDraggableMap.dragBounds.extents = extentSize[i];
    }
}
