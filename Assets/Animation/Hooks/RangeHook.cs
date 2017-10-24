using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeHook : MonoBehaviour {

    // Use this for initialization
    public void AttackMoment() {
        this.transform.parent.GetComponent<RangeAttack>().AttackMoment();
    }
}
