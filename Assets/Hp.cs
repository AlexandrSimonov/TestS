using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hp : MonoBehaviour {

    public float hp = 0;
    public hub hub;
    public HpChangeEvent events;

    void Start() {
        if (hub != null) {
            hub.Init(hp, hp);
        }
    }

    public void Minus(float count) {
        hp -= count;
        events.Invoke(hp);

        if (hp > 0) {
            Debug.Log("Боль");
        } else {
            Debug.Log("Уже всё равно");
            Destroy(this.gameObject);
        }
    }

    [System.Serializable]
    public class HpChangeEvent : UnityEvent<float> {}
}
