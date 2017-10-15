using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SubtitleDatabase
{
    public Sprite subtitleSprite;
    public float triggerTime;
}

public class SubtitleData : ScriptableObject {

    [SerializeField]
    public List<SubtitleDatabase> subtitleDatas = new List<SubtitleDatabase>();
}
