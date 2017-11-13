using UnityEngine;

[System.Serializable]
public class PathExit {
    
    // Клетки выхода, через которые можно совершить выход в одну из зон входа
    public PathNode PathNodeExit;
    public PathNode PathNodeEnter;

    public Vector3 coo; // Координаты выхода, чтобы быстро искать вход и выход

    public PathZone enter;
}