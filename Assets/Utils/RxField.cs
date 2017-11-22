using UnityEngine.Events;

// RxField это поле которое просто уведомляет об своем изменении
public class RxField<T> : System.Object {
    private T _value;
    public RxEvent OnChangeEvent = new RxEvent();

    public int k = 0;

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