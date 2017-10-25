using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEditor;

public class Shell : MonoBehaviour {

    private GameObject target;
    public float speed;
    private float damage;
    private DamageType type;
    public UnityEvent destroyShell;
    private IEffectActivate[] activateEffects;

    public void Init(GameObject target, float damage, DamageType type) {
        this.target = target;
        this.damage = damage;
        this.type = type;
    }

    // Он будет лететь в низ геймобжекта(в ноги), нужно как-то обсчитывать чтобы летел в центр
    void Update() {
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.1f) {

                target.GetComponent<IDamaged>().Hit(damage, type);

                foreach (IEffectActivate effect in activateEffects) {
                    effect.Activate(target);
                }

                destroyShell.Invoke();
                this.enabled = false;
                
                //Destroy(this.gameObject);
            }
        }        
    }
}
