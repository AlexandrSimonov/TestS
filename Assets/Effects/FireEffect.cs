using UnityEngine;
using System.Collections;

public class FireEffect : Effect {

    public float damage;
    private Hp hp;

    public override void OnInitEffect() {
        hp = target.GetComponent<Hp>();
    }

    public override void EffectUpdate() {
        hp.Minus(damage * Time.deltaTime);
    }

}
