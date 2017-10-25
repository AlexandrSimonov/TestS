using UnityEngine;
using System.Collections;

public class RegenEffectActivate : RegenEffect, IEffectActivate {

    public GameObject prefab;

    public void Activate(GameObject target) {
        RegenEffect effect = Instantiate(prefab, target.transform).GetComponent<RegenEffect>();

        effect.ActiveEffect();

    }
}
