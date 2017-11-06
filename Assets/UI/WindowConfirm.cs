using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class WindowConfirm : MonoBehaviour {
    public GameObject background;
    public GameObject window;

    public Text title;
    public Text message;

    private UnityAction ok;
    private UnityAction fail;
    private static WindowConfirm instance;

    private void Start() {
        instance = this;
    }

    public static void Open(string title, string message, UnityAction callbackOk, UnityAction callbackFail) {
        instance.title.text = title;
        instance.message.text = message;

        instance.ok = callbackOk;
        instance.fail = callbackFail;

        instance.background.SetActive(true);
        instance.window.SetActive(true);
    }

    public void Okay() {
        instance.ok.Invoke();
        instance.background.SetActive(false);
        instance.window.SetActive(false);
    }

    public void Fail() {
        if (instance.fail != null) {
            instance.fail.Invoke();
        }
        instance.background.SetActive(false);
        instance.window.SetActive(false);
    }
}
