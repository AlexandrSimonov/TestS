using UnityEngine;
using System.Collections;

public abstract class Effect: MonoBehaviour, IEffect {

    public float duration;
    protected float durationTimer;

    public void ActiveEffect() {
        durationTimer += Time.time + duration;
        OnActive();
    }

    public abstract void OnActive();
}