using UnityEngine;
using UnityEditor;

public class HealingSalve : Item {

    public override void Activate(GameObject target) {
        Debug.Log(target.name + " лечится");
    }

    public override void DeActivate() {}

    public override void GetInfo() {}

}