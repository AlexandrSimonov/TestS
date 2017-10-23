using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Unit/Attack/RangeAttack")]
public class RangeAttack : Attack {

    public Shell shell;
    public Transform pos;

    private IDamaged target;

    public override void AttackUnit(GameObject target) {

        this.target = target.GetComponent<IDamaged>();
        
        if (this.target != null && Vector3.Distance(target.transform.position, transform.position) <= range && Time.time >= timerDelay) {
            Shell shellObj = Instantiate(shell.gameObject, pos.position, new Quaternion()).GetComponent<Shell>();
            shellObj.Init(target, strong, damageType);
            timerDelay = Time.time + delay;
        }
    }
    void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + range, transform.position.y));
    }
}
