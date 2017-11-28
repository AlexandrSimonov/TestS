using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "FireEffect", menuName = "Effects/FireEffect", order = 1)]
public class FireEffect : Effect {

    public float damage;

    public override void Start() {
        Debug.Log("Fire effect");
    }

    public override void Update() {
        Debug.Log("Damage" + damage);
        Delete();
    }

}
