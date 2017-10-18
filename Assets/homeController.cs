using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeController : MonoBehaviour {

    public float speed = 1;
    public Animator animator;
    public SpriteRenderer sprite;

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
    }
    
    private void reset() {
        animator.SetBool("walk", false);
        animator.SetBool("hurt", false);
    }

    public void hpMinus(GameObject from) {
        animator.SetBool("hurt", true);
    }

    public void hpDie() {
        animator.SetBool("die", true);
        Debug.Log("Вы проиграли");
    }
}
