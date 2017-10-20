using UnityEngine;
using System.Collections;



public class Shell : MonoBehaviour {

    public delegate void WhateverType();

    protected WhateverType callbackFct; 

    private Vector2 target;
    public float speed;
    private WhateverType myCallback;

    public void Init(Vector2 target, WhateverType myCallback) {
        this.myCallback = myCallback;
    }

    // Он будет лететь в низ геймобжекта(в ноги), нужно как-то обсчитывать чтобы летел в центр
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed);
        
        if (Vector2.Distance(transform.position, target) < 0.1f) {

            myCallback();

            Destroy(this.gameObject);
        }
    }
}
