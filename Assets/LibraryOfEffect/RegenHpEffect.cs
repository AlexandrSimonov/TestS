using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "RegeHpEffect", menuName = "Effects/RegenHpEffect", order = 1)]
public class RegenHpEffect : Effect {

    public float regen;
    private Hp hp;
    public override void Start() {
        Hp hp = target.gameObject.GetComponent<Hp>();
        if (hp != null) {
            this.hp = hp;
        }
    }

    public override void Update() {
        Debug.Log("Regen " + regen);
    }
}
