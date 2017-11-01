using UnityEngine;
using System.Collections;

public class RegenHpEffect : Effect {

    public float regen;
    private Hp hp;

    public override void OnInitEffect() {
        hp = target.GetComponent<Hp>();
        if (hp == null) {
            Debug.LogError("Нужно накинуть на объект компонент Hp");
            BreakEffect();
        }
    }

    public override void EffectUpdate() {
        hp.Plus(regen * Time.deltaTime);
    }

    public override void OnBeforeBreakEffect() {
        Debug.Log("Effect сбошен");
    }
}
