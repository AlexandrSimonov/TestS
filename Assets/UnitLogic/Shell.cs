using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Shell : MonoBehaviour {

    private GameObject target;
    public float speed;
    private float damage;
    private DamageType type;
    public UnityEvent destroyShell;
    private IEffect[] activateEffects;

    public void Init(GameObject target, float damage, DamageType type) {
        this.target = target;
        this.damage = damage;
        this.type = type;

        activateEffects = GetComponents<IEffect>();

        Debug.Log(activateEffects.Length);
    }

    // Он будет лететь в низ геймобжекта(в ноги), нужно как-то обсчитывать чтобы летел в центр
    void Update() {
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.1f) {

                target.GetComponent<IDamaged>().Hit(damage, type);

                EffectActivate effAct = target.GetComponent<EffectActivate>();

                if (effAct != null) {
                    foreach (IEffect effect in activateEffects) {
                        effect.InitEffect(effAct);
                    }
                }
                
                destroyShell.Invoke();
                this.enabled = false;
                
                //Destroy(this.gameObject);
            }
        }        
    }
}
