using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class WindowConfirm : MonoBehaviourSingelton<WindowConfirm> {

    public Window window;

    public Text title;
    public Text message;

    private UnityAction ok;
    private UnityAction fail;

    public static void Open(string title, string message, UnityAction callbackOk, UnityAction callbackFail) {
        Instance.title.text = title;
        Instance.message.text = message;

        Instance.ok = callbackOk;
        Instance.fail = callbackFail;

        Instance.window.Open();
    }

    public void Okay() {
        Instance.ok.Invoke();

        Instance.window.Close();
    }

    public void Fail() {
        if (Instance.fail != null) {
            Instance.fail.Invoke();
        }
        
        Instance.window.Close();
    }
}
