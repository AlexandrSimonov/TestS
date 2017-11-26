using System.Linq;
using UnityEngine;
using UnityEditor;

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject {
    private static T instance = null;

    protected static T Instance {
        get {
            if (instance == null) {
                instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();

                if (instance == null) {
                    Debug.LogError("Singelton error " + typeof(T));
                }
            }
            return instance;
        }
    }

}