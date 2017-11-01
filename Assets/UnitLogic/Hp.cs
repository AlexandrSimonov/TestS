using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hp : MonoBehaviour {

    [HideInInspector]
    public float hp = 0;
    public float maxHp = 0;

    public HpChangeEvent OnHpChangeEvent;

    public UnityEvent OnHpDieEvent;

    private void Start() {
        hp = maxHp;
    }

    public void Plus(float count) {
        Change(count);   
    }

    public void Minus(float count) {
        Change(-count);
    }

    private void Change(float count) {
        hp += count;

        OnHpChangeEvent.Invoke(hp);

        if (hp <= 0) {
            OnHpDieEvent.Invoke();
        }

        if (hp > maxHp) {
            hp = maxHp;
        }
    }


    [System.Serializable]
    public class HpChangeEvent : UnityEvent<float> { }
}
