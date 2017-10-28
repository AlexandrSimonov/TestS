using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectActivate : MonoBehaviour {

    private List<IEffectActivate> effects = new List<IEffectActivate>();

    public void Init(IEffectActivate effect) {
        effects.Add(effect);
    }

    //Нужно будет проверить "участок"
    void Update() {
        for (int i = 0; i < effects.Count; i++) {
            if ( effects[i].EffectLoop()) {
                effects.RemoveAt(i);
            }
        }
    }
}