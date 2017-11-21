using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour, IAttack {

    public float delay = 0;
    protected float timerDelay;

    public float strong = 0;
    public float range = 0;
    public float attackDistance = 1;

    public DamageType damageType;

    public abstract void AttackUnit(GameObject target);

    public float GetDistanceAttack() {
        return attackDistance;
    }
}
