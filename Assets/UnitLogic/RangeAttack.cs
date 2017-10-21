using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Unit/Attack/RangeAttack")]
public class RangeAttack : Attack {

    public float strong = 0;
    public float range = 0;

    public Shell shell;

    private IDamaged target;
    public override void AttackUnit(GameObject target) {

        this.target = target.GetComponent<IDamaged>();
        
        if (Vector2.Distance(target.transform.position, transform.position) <= range) {
            Shell shellObj = Instantiate(shell.gameObject, transform.position, new Quaternion(), transform).GetComponent<Shell>();
            shellObj.Init(target.transform.position, ShellBum);
        }
    }

    private void ShellBum() {
        target.Hit(strong, DamageType.Physic);
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + range, transform.position.y));
    }
}
