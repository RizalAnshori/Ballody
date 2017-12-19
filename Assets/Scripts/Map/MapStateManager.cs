using UnityEngine;
using System.Collections;

public class MapStateManager {

    public static MapState mapState = MapState.Accessible;
}

[System.Serializable]
public enum MapState
{
    Accessible,
    Unaccesible
}
