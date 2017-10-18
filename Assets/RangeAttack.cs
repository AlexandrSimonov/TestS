using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Unit/Attack/RangeAttack")]
public class RangeAttack : Attack {

    public float strong = 0;
    public float range = 0;

    void Start() {

    }

    public override void AttackUnit() { }

    void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + range, transform.position.y));
    }
}
