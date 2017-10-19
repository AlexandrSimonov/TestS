using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveControl : MonoBehaviour {

    public bool isEnd;

    private static WaveControl instance;
    public UnityEvent OnWaveEnd;
    public UnityEvent OnWaveStart;

    private int countMonster = 0;

    void Start() {
        isEnd = true;
        instance = this;
        countMonster = 1;
    }

    public void WaveStart() {
        OnWaveStart.Invoke();
    }

    public static void MonsterDie() {
        instance.countMonster--;

        if (instance.countMonster == 0) {
            instance.OnEnd();
            instance.OnWaveEnd.Invoke();
        }
    }

    private void OnEnd() {
        DialogSystem.AddMessage("Конец волны", 4);
        magicDust.AddMoney(100);
    }
}
