using UnityEngine.Events;

public class RxField<T> {
    private T _value;
    public RxEvent OnChangeEvent = new RxEvent();

    public T Value {
        get {
            return _value;
        }
        set {
            _value = value;
            OnChangeEvent.Invoke(_value);
        }
    }

    public RxField(T defaultValue) {
        Value = defaultValue;
    }

    public class RxEvent : UnityEvent<T> { }
}