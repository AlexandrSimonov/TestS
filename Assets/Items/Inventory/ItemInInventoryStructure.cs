using UnityEngine;
using UnityEngine.Events;
// Вот эту штуку нужно пределать, чтобы можно было сразу несколько вещей покупать
// Просто хранит своё состояние и может им управлять
[System.Serializable]
public class ItemInInventoryStructure {
    public Item item;
    public int count;

    [HideInInspector]
    public UnityEvent changeEvent;

    // Определяем вообще всё что можно делать с этим предметом, если он в инвентаре и не важно откуда
    public void Throw() {
        changeEvent.Invoke();
    }
    public void Activate() {
        changeEvent.Invoke();
    }

    public void Sell() {
        changeEvent.Invoke();
    }
}
