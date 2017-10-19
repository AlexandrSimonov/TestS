using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveControl : MonoBehaviour {

    public GameObject enemies;
    public bool isEnd;
    private static WaveControl instance;
    public UnityEvent OnWaveEnd;
    public UnityEvent OnWaveStart;

    void Start() {
        isEnd = true;
        instance = this;
    }

    public void WaveStart() {

    }

    public static void MonsterDie() {
        if (instance.enemies.transform.childCount == 0) {
            instance.OnEnd();
            instance.OnWaveEnd.Invoke();
        }
    }

    private void OnEnd() {
        DialogSystem.AddMessage("Конец волны", 4);
        magicDust.AddMoney(100);
    }
}
