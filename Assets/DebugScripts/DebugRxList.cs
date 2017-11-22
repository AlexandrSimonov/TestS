using UnityEngine;
using System.Collections;

public class DebugRxList : MonoBehaviour {

    private RxList<int> integers = new RxList<int>();

    // Пока события работают нормально и можно с этим классом(после некоторого времени) переписать к примеру инвентарь
    void Start() {
        integers.OnAddEvent.AddListener(OnAdd);
        integers.OnRemoveEvent.AddListener(OnRemove);

        integers.Add(1);
        integers.Add(2);
        integers.Add(3);

        integers.Remove(2);

        Debug.Log("---Список---");

        foreach (int i in integers) {
            Debug.Log(i);
        }
    }

    private void OnAdd(int item) {
        Debug.Log("Add " + item);
    }

    private void OnRemove(int item) {
        Debug.Log("Remove " + item);
    }
}
