using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public abstract class Effect : ScriptableObject {

    protected float TimeEnd;
    protected EffectTarget target;

    public Effect CloneEffect() {
        return this.MemberwiseClone() as Effect;
    }

    public virtual void Init(EffectTarget target) {
        this.target = target;
    }

    public virtual void Start() {

    }

    public virtual void Update() {

    }

    public virtual void Delete() {
        target.Delete(this); // Вызывается удаление из списка эффектов
    }
}