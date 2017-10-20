using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour, IAttack {

    public abstract void AttackUnit(GameObject target);
	
    
}
