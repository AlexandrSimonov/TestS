using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveControl : MonoBehaviour {

    public GameObject enemies;
    public bool isEnd;
    private static WaveControl instance;
    public UnityEvent WaveEnd;

    void Start() {
        isEnd = true;
        instance = this;

    }

    public static void MonsterDie() {
        if (instance.enemies.transform.childCount == 0) {
            instance.OnEnd();
            instance.WaveEnd.Invoke();
        }
    }

    private void OnEnd() {
        DialogSystem.AddMessage("Конец волны", 4);
        magicDust.AddMoney(100);
    }
}
