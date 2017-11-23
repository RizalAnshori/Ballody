using UnityEngine;
using MadLevelManager;
using System.Collections;

public class TargetMapChanger : MonoBehaviour {

    [SerializeField] MadFreeDraggable[] draggableArea;
    [SerializeField] Vector2[] mapPositions;

	public void MoveToMap(int index)
    {
        for(int i = 0; i<draggableArea.Length; i++)
        {
            draggableArea[i].MoveToLocal(mapPositions[index], MadiTween.EaseType.easeOutQuad, 0.5f);
        }
    }
}
