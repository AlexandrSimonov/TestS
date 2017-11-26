using UnityEngine;
using System.Collections;

public class Bootstrap : MonoBehaviour {

    public ScriptableObjectInit[] singletons;

    void Awake() {
        foreach (ScriptableObjectInit singleton in singletons) {
            singleton.Init();
        }
    }

}
