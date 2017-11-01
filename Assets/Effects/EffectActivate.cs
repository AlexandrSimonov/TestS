using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectActivate : MonoBehaviour {

    private List<IEffectActivate> effects = new List<IEffectActivate>();

    //Метод вызываемый из Effect
    public void Init(IEffectActivate effect) {
        effects.Add(effect);
        Debug.Log("Effect Add " + effect.GetType());
    }

    // Метод вызываемый откуда угодно
    public void Break(IEffectActivate effect) {
        effect.BreakEffect();
    }

    // Вызывается из Effect
    public void RemoveEffect (IEffectActivate effect) {
        effects.Remove(effect);
        Debug.Log("Remove Add " + effect.GetType());
    }

   
    void Update() {
        for (int i = 0; i < effects.Count; i++) {
            if (effects[i].EffectLoop()) {
                RemoveEffect(effects[i]);
            }
        }
    }
}