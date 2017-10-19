using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterController : MonoBehaviour {

    public Animator animator;
    public SpriteRenderer sprite;

    void Start() {
        IAttack[] atacks = GetComponents<IAttack>();
        if (atacks.Length != 1) {
            Debug.LogError("Много компонентов атаки");
        }
    }

    public void OnHpDie() {
        magicDust.AddMoney(10);
        WaveControl.MonsterDie();

        // Проиграть анимацию смерти и т.д, то есть сам объект не удаляется, а просто отметить, что он мертв
        Destroy(this.gameObject);
    }
}


/*
 public float speed = 1;


    public GameObject target = null;
    public float stop = 0;

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

    // Update is called once per frame
    void Update() {
        reset();

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
            targetHp.minus(10, transform.gameObject);
            atackTimer = Time.time + 0.8f;
            animator.SetBool("atack", true);
        }
    }

    private void move() {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        animator.SetBool("walk", true);
    }

    private void reset() {
        animator.SetBool("walk", false);
        animator.SetBool("hurt", false);
    } 
     
*/
