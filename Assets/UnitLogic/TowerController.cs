using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerController : MonoBehaviour {

    private Attack attack;
    private Hp hp;
    private Monster target;

    public enum TowerMode {
        PriorityAttack,
        AttackTarget,
        DefaultAttack
    }

    private TowerMode mode;

	// Use this for initialization
	void Start () {
        attack = GetComponent<Attack>();
        hp = GetComponent<Hp>();

       
        target = null;
        mode = TowerMode.DefaultAttack;
	}

    private float GetDistanceToMonster(Monster monster) {
        return Vector3.Distance(monster.transform.position, transform.position);
    }

    private Monster GetMonster() {
        Monster[] monsters = WaveControl.GetMonsters();
        Monster monsterReturn = null;

        if (monsters.Length > 0) {
            monsterReturn = monsters[0];

            foreach (Monster monster in monsters) {
                float distance = GetDistanceToMonster(monster);
                if (distance <= attack.GetDistanceAttack() && distance < GetDistanceToMonster(monsterReturn)) {
                    monsterReturn = monster;
                }
            }
        }

        return monsterReturn;
    }

    
    void Update() {
        //Можно сделать задержку для поиска монтров
        if (target == null) {
            target = GetMonster();
        } else {
            attack.AttackUnit(target.GetComponent<Damaged>()); // Вообще эта фигня должна принимать IDamaged
        }
	}
}
