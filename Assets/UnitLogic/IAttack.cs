using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack {
    void AttackUnit(GameObject target);

    float GetDistanceAttack();
}
