using UnityEngine;
using System.Collections;

public class FireEffect : Effect {

    private Hp hp;
    public float damage;

    private void Update() {
        if (Time.time < durationTimer) {
            hp.Minus(damage * Time.deltaTime);
        }
    }

    public override void OnActive() {
        hp = transform.GetComponent<Hp>();
    }
}
