using UnityEngine;
using UnityEditor;

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject {
    private static T instance = null;

    protected static T Instance {
        get {
            if (instance == null) {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null) {
                    Debug.LogError("Singleton error" + typeof(T));
                }
            }
            return instance;
        }
    }
}