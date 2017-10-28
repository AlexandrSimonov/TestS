using UnityEngine;
using System.Collections;

public class ColliderSection : GOSection {


    public override void Activate() {
        
    }

    void OnTriggerEnter(Collider gameObject) {
        slot.Activate(gameObject.gameObject);
    }
}
