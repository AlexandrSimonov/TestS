using UnityEngine.Events;

// RxField это поле которое просто уведомляет об своем изменении
public class RxField<T> : System.Object {
    private T _value;
    public RxEvent OnChangeEvent = new RxEvent();

    // https://habrahabr.ru/post/314306/
    // Там написано молв, свойства - это медленно в unity
    // Стоит это проверить и протестировать
    // Тест https://habrahabr.ru/post/314306/#comment_9906290
    // 
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