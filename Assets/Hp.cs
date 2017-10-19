using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hp : MonoBehaviour {

    public float hp = 0;

    [HideInInspector]
    public HpChangeEvent hpChangeEvent;

    public UnityEvent hpDieEvent;


    public void Plus(float count) {
        Change(count);   
    }

    public void Minus(float count) {
        Change(-count);
    }

    private void Change(float count) {
        hp += count;
        hpChangeEvent.Invoke(hp);
        if (hp <= 0) {
            hpDieEvent.Invoke();
        }
    }


    [System.Serializable]
    public class HpChangeEvent : UnityEvent<float> { }
}
