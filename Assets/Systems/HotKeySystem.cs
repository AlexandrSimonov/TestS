using UnityEngine;
using System.Collections;

public class HotKeySystem : MonoBehaviour {

    public HotKey[] hotkeys;

    private void Awake() {
        Debug.Log("Проверочки хот кеев");
    }

    private void Update() {
        foreach (HotKey hotkey in hotkeys) {
            if (Input.GetKeyDown(hotkey.hotkey)) {
                hotkey.action.Invoke();
            }
        }
    }
}
