using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

// Вот эту штуку переделаем под ScriptableObject
public abstract class Effect : MonoBehaviour, IEffect, IEffectActivate {

    public float duration;

    protected float TimeEnd;
    protected EffectActivate effectActivate;
    protected GameObject target;

    // Вызывается из вне
    public void InitEffect(EffectActivate target) {
        effectActivate = target;
        this.target = target.gameObject;

        TimeEnd = Time.time + duration;

        if (this.target == null) {
            throw new Exception("EffectActivate is not gameObject");
        }

        IEffectActivate effect = GetCopyEffect();
        effectActivate.Init(effect);
        effect.OnInitEffect();
    }

    // Переопрделяется в реализаторе абстрактного класса и вызывается в EventLoop
    public abstract void EffectUpdate();

    // Вызывается из EffectActivate
    public bool EffectLoop() {
        if (TimeEnd <= Time.time) {
            return true;
        }

        EffectUpdate();

        return false;
    }

    // Переопределяется в реализаторе абстрактного класса и вызывается в InitEffect
    public abstract void OnInitEffect();

    public virtual void OnBeforeBreakEffect() { }

    // Вызывается для преривания эффекта как из вне так и внутри
    public void BreakEffect() {
        OnBeforeBreakEffect();

        effectActivate.RemoveEffect(this);
    }

    // Вызывается из InitEffect для создания коппи текущего объекта
    public IEffectActivate GetCopyEffect() {
        return this.MemberwiseClone() as IEffectActivate;
    }
}