using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class WaveControl : MonoBehaviour {

    public bool isEnd;

    private static WaveControl instance;

    public UnityEvent OnWaveEnd;
    public UnityEvent OnWaveStart;

    private int countMonster = 0;

    public Monster[] monsters;

    public Transform parentMonster;

    private int strongWave;

    private MonsterSpawnZone zone;


    void Start() {
        strongWave = 5;

        if (monsters == null) {
            Debug.LogError("Массив с монстрами пустой");
        }

        zone = GetComponent<MonsterSpawnZone>();

        isEnd = true;
        instance = this;
        instance.OnWaveEnd.Invoke();

        GetRandomMonster(4);
    }

    public void WaveStart() {
        OnWaveStart.Invoke();

        int currentStrong = 0;

        while (currentStrong != strongWave) {
            Monster monster = GetRandomMonster(strongWave - currentStrong);

            Instantiate(monster.gameObject, zone.GenerateRandomPoint(), new Quaternion(0, 0, 0, 0), parentMonster);

            currentStrong += monster.strong;

            countMonster++;
        }
        
    }

    private Monster GetRandomMonster(int canStrong) {
        Monster[] canMonsters = monsters.Where(monster => monster.strong <= canStrong).ToArray();
        
        return canMonsters[Random.Range(0, canMonsters.Length)];
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
        MagicDust.Plus(100);
        strongWave += 5;
    }
}
