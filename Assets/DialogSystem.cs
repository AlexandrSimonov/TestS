using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour {

    public GameObject parent;
    public GameObject DialogMessage;

    public static DialogSystem instance;

    private void Start() {
        DialogSystem.instance = this;
    }

    public static void AddMessage(string text, float time) {
        GameObject message = Instantiate(instance.DialogMessage, instance.parent.transform);
        message.GetComponent<Dialog>().Init(text, time);
    }
}
