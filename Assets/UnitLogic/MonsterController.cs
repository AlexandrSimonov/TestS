using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
    private GameObject target;
    public float speed = 1;

    void Start() {
        IAttack[] atacks = GetComponents<IAttack>();

        if (atacks.Length != 1) {
            Debug.LogError("Много компонентов атаки");
        }

        GameObject[] targets = GameObject.FindGameObjectsWithTag("targetOfMonster");

        if (targets.Length > 0) {

            target = targets[0];

            for (int i = 0; i < targets.Length; i++) {
                if (Vector3.Distance(targets[i].transform.position, transform.position) < Vector3.Distance(target.transform.position, transform.position)) {
                    target = targets[i];
                }
            }
        }

    }

    public float stop = 0;

    // Update is called once per frame
    void Update() {
        if (target != null && stop == 0) {
            if (Vector3.Distance(transform.position, target.transform.position) < 2) {
                atack();
            } else {
                move();
            }
        }
    }
    float atackTimer = 0;

    private void atack() {
        if (atackTimer < Time.time) {
            Hp targetHp = target.GetComponent(typeof(Hp)) as Hp;
            targetHp.Minus(10);
            atackTimer = Time.time + 0.8f;

        }
    }

    private void move() {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }

    public void OnHpDie() {
        MagicDust.Plus(10);
        WaveControl.MonsterDie();

        // Проиграть анимацию смерти и т.д, то есть сам объект не удаляется, а просто отметить, что он мертв
        Destroy(this.gameObject);
    }
}


/*





    void Start() {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("targetOfMonster");

        if (targets.Length > 0) {

            target = targets[0];

            for (int i = 0; i < targets.Length; i++) {
                if (Vector3.Distance(targets[i].transform.position, transform.position) < Vector3.Distance(target.transform.position, transform.position)) {
                    target = targets[i];
                }
            }
        }

    }


     
*/
