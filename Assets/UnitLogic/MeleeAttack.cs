using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Unit/Attack/MeleeAttack")]
public class MeleeAttack : Attack {
    
    public override void AttackUnit(Damaged target) {
        if (Vector2.Distance(target.transform.position, transform.position) <= range && Time.time >= timerDelay) {
            target.Hit(strong, damageType);
            timerDelay = Time.time + delay;
        } 
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + range, transform.position.y));
    }
}
