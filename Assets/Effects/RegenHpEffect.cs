using UnityEngine;
using System.Collections;

public class RegenHpEffect : Effect {

    public float regen;
    private Hp hp;

    public override void EffectInit() {
        hp = target.GetComponent<Hp>();
    }

    public override void EffectUpdate() {
        hp.Plus(regen * Time.deltaTime);
    }
}
