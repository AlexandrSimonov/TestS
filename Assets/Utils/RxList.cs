using UnityEngine.Events;
using System.Collections.Generic;

public class RxList<T> : List<T> {

    public RxEvent OnAddEvent = new RxEvent();
    public RxEvent OnRemoveEvent = new RxEvent();
    public UnityEvent OnClearEvent = new UnityEvent();

    // Приставка Rx будет значить, что вызов метода вызывает событие
    public void RxAdd(T item) {
        base.Add(item);
        OnAddEvent.Invoke(item);
    }

    public void RxRemove(T item) {
        base.Remove(item);
        OnRemoveEvent.Invoke(item);
    }

    public void RxClear() {
        base.Clear();
        OnClearEvent.Invoke();
    }

    public class RxEvent : UnityEvent<T> { }
}