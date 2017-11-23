using UnityEngine;
using System.Collections;

public class DebugRxList : MonoBehaviour {

    private RxList<int> integers = new RxList<int>();

    // Пока события работают нормально и можно с этим классом(после некоторого времени) переписать к примеру инвентарь
    void Start() {
        integers.OnAddEvent.AddListener(OnAdd);
        integers.OnRemoveEvent.AddListener(OnRemove);

        integers.RxAdd(1);
        integers.RxAdd(2);
        integers.RxAdd(3);

        integers.RxRemove(2);

        Debug.Log("---Список---");

        //integers.RxClear();

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
