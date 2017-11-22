using UnityEngine.Events;
using System.Collections.Generic;

public class RxList<T> : List<T> {

    public RxEvent OnAddEvent = new RxEvent();
    public RxEvent OnRemoveEvent = new RxEvent();

    public new void Add(T item) {
        base.Add(item);

        // И вот тут магия
        OnAddEvent.Invoke(item);
    }

    public new void Remove(T item) {
        base.Remove(item);

        OnRemoveEvent.Invoke(item);
    }

    public class RxEvent : UnityEvent<T> { }
}