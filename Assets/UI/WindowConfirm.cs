using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class WindowConfirm : MonoBehaviourSingelton<WindowConfirm> {
    public GameObject background;
    public GameObject window;

    public Text title;
    public Text message;

    private UnityAction ok;
    private UnityAction fail;

    public static void Open(string title, string message, UnityAction callbackOk, UnityAction callbackFail) {
        Instance.title.text = title;
        Instance.message.text = message;

        Instance.ok = callbackOk;
        Instance.fail = callbackFail;

        Instance.background.SetActive(true);
        Instance.window.SetActive(true);
    }

    public void Okay() {
        Instance.ok.Invoke();
        Instance.background.SetActive(false);
        Instance.window.SetActive(false);
    }

    public void Fail() {
        if (Instance.fail != null) {
            Instance.fail.Invoke();
        }
        Instance.background.SetActive(false);
        Instance.window.SetActive(false);
    }
}
