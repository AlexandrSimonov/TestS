using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hp : MonoBehaviour {

    public float hp = 0;

    [HideInInspector]
    public HpChangeEvent OnHpChangeEvent;

    public UnityEvent OnHpDieEvent;


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
            this.gameObject.SetActive(false);
        }
    }


    [System.Serializable]
    public class HpChangeEvent : UnityEvent<float> { }
}
