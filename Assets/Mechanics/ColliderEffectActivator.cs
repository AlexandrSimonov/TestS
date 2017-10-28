using UnityEngine;
using System.Collections;

public class ColliderEffectActivator : MonoBehaviour {

    public bool deleteInEnd;
    public float delayBeforeActivate;
    private float delayBeforeActivateTimer;

    private IEffect[] effects;

    void Start() {
         effects = GetComponents<IEffect>();
         
    }

    
    void OnTriggerStay(Collider gameObject) {
        if (delayBeforeActivate != -1 && delayBeforeActivateTimer > Time.time) {
            return;
        }

        EffectActivate act = gameObject.GetComponent<EffectActivate>();

        foreach (IEffect effect in effects) {
            effect.InitEffect(act);
        }

        delayBeforeActivateTimer = Time.time + delayBeforeActivate;
        if (deleteInEnd) {
            Destroy(this.gameObject);
        }
        
    }
}
