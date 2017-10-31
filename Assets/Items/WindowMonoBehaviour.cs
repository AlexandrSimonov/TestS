using UnityEngine;
using System.Collections;

public abstract class WindowMonoBehaviour : MonoBehaviour {
    public GameObject window;

    public void OpenWindow() {
        window.SetActive(true);
    }

    public void CloseWindow() {
        window.SetActive(false);
    }

    public void ChangeWindowState() {
        window.SetActive(!window.activeSelf);
    }
}
