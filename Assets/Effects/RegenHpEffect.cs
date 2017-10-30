using UnityEngine;
using System.Collections;

public class RegenHpEffect : Effect {

    public float regen;
    private Hp hp;

    public override void OnInitEffect() {
        // Если на объекте нет компонента здоровья...
        hp = target.GetComponent<Hp>();
    }

    public override void EffectUpdate() {
        hp.Plus(regen * Time.deltaTime);
    }
}
