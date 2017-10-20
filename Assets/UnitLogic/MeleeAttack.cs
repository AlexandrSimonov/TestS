using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Unit/Attack/MeleeAttack")]
public class MeleeAttack : Attack {

    public float strong = 0;
    public float range = 0;

    public DamageType damageType;

    public override void AttackUnit(GameObject target) {
        if (Vector2.Distance(target.transform.position, transform.position) <= range) {
            IDamaged damaged = target.GetComponent<IDamaged>();
            if (damaged != null) {
                damaged.Hit(strong, damageType);
            }
        } 
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + range, transform.position.y));
    }
}
