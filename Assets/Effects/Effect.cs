using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

public abstract class Effect : MonoBehaviour, IEffect, IEffectActivate {

    public float duration;
    protected float TimeEnd;
    protected GameObject target;

    public void InitEffect(EffectActivate target) {
        TimeEnd = Time.time + duration;
        this.target = target.gameObject;
        target.Init(InitInActivate());
    }

    public abstract void EffectUpdate();

    public bool EffectLoop() {
        if (TimeEnd <= Time.time) {
            return true;
        }

        EffectUpdate();

        return false;
    }

    public abstract void EffectInit();

    public IEffectActivate InitInActivate () {
        IEffectActivate effect = this.MemberwiseClone() as IEffectActivate;

        effect.EffectInit();
        return effect;
    }
}