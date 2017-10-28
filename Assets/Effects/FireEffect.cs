using UnityEngine;
using System.Collections;

public class FireEffect : Effect {

    public float damage;
    private Hp hp;

    public override void EffectInit() {
        hp = target.GetComponent<Hp>();
    }

    public override bool EffectUpdate() {
        if (TimeEnd <= Time.time) {
            return true;
        }
        hp.Minus(damage * Time.deltaTime);
        return false;
    }

}
