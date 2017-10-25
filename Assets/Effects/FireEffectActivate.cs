using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffectActivate : FireEffect, IEffectActivate {

    public GameObject prefab;

    public void Activate(GameObject target) {
        FireEffect effect = Instantiate(prefab, target.transform).GetComponent<FireEffect>();

        
        effect.ActiveEffect();

    }
}
