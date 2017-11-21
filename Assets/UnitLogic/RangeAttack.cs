using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Unit/Attack/RangeAttack")]
public class RangeAttack : Attack {


    public Shell shell;
    public Transform pos;
    public Animator animator;

    private Damaged target;

    public override void AttackUnit(Damaged target) {
        animator.SetBool("attack", true);
        
        this.target = target;
    }

    public void AttackMoment() {
        if (target != null && Vector3.Distance(target.transform.position, transform.position) <= range && Time.time >= timerDelay) {
            Shell shellObj = Instantiate(shell.gameObject, pos.position + new Vector3(0, 0, shell.GetComponent<SphereCollider>().radius), new Quaternion()).GetComponent<Shell>();
            shellObj.Init(target.gameObject, strong, damageType);
            timerDelay = Time.time + delay;
        }
    }
    void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + range, transform.position.y));
    }
}
