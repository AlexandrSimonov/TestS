using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class WaveControl : MonoBehaviourSingelton<WaveControl> {

    public bool isEnd;

    public UnityEvent OnWaveEnd;
    public UnityEvent OnWaveStart;

    public Monster[] monsters;

    public Transform parentMonster;

    private int strongWave;


    public List<Monster> waveMonster;

    void Start() {
        strongWave = 5;

        if (monsters == null) {
            Debug.LogError("Массив с монстрами пустой");
        }

        isEnd = true;

        Instance.OnWaveEnd.Invoke();

        GetRandomMonster(4);

        waveMonster = new List<Monster>();
    }

    public static Monster[] GetMonsters() {
        return Instance.waveMonster.ToArray();
    }

    public void WaveStart() {
        OnWaveStart.Invoke();

        int currentStrong = 0;

        while (currentStrong != strongWave) {
            Monster monster = GetRandomMonster(strongWave - currentStrong);
            // Вот тут не правльно и нужно выбирать случайную позицию
            waveMonster.Add(Instantiate(monster.gameObject, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), parentMonster).GetComponent<Monster>());

            currentStrong += monster.strong;
        }
    }



    private Monster GetRandomMonster(int canStrong) {
        Monster[] canMonsters = monsters.Where(monster => monster.strong <= canStrong).ToArray();

        return canMonsters[Random.Range(0, canMonsters.Length)];
    }


    public static void MonsterDie(Monster monster) {
        Instance.waveMonster.Remove(monster);

        if (Instance.waveMonster.Count == 0) {
            Instance.OnEnd();
            Instance.OnWaveEnd.Invoke();
        }
    }

    private void OnEnd() {
        Notification.CreateNotification(Notification.NotificationPriority.Middle, "Конец волны");
        MagicDust.Plus(100);
        strongWave += 5;
    }
}
