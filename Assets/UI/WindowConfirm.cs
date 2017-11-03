using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class WindowConfirm : MonoBehaviour {

    public Text title;
    public Text message;

    private UnityAction ok;
    private UnityAction fail;
    private static WindowConfirm instance;

    private void Start() {
        instance = this;

        gameObject.SetActive(false);
    }

    public static void Open(string title, string message, UnityAction callbackOk, UnityAction callbackFail) {
        instance.title.text = title;
        instance.message.text = message;

        instance.ok = callbackOk;
        instance.fail = callbackFail;

        instance.gameObject.SetActive(true);
    }

    public void Okay() {
        instance.ok.Invoke();
        instance.gameObject.SetActive(false);
    }

    public void Fail() {
        if (instance.fail != null) {
            instance.fail.Invoke();
        }
        instance.gameObject.SetActive(false);
    }
}
