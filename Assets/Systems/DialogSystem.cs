using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviourSingelton<DialogSystem> {

    public GameObject parent;
    public GameObject DialogMessage;

    public static void AddMessage(string text, float time) {
        GameObject message = Instantiate(Instance.DialogMessage, Instance.parent.transform);
        message.GetComponent<Dialog>().Init(text, time);
    }
}
