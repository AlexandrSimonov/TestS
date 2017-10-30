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

        if (this.target == null) {
            throw new Exception("EffectActivate is not gameObject");
        }
        
        target.Init(GetCopyEffect());
    }

    public abstract void EffectUpdate();

    public bool EffectLoop() {
        if (TimeEnd <= Time.time) {
            return true;
        }

        EffectUpdate();

        return false;
    }

    public abstract void OnInitEffect();

    public IEffectActivate GetCopyEffect() {
        IEffectActivate effect = this.MemberwiseClone() as IEffectActivate;
        effect.OnInitEffect();

        return effect;
    }
}