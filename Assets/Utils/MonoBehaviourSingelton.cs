using UnityEngine;
using System.Collections;

public class MonoBehaviourSingelton <T> : MonoBehaviour where T : MonoBehaviour {

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
