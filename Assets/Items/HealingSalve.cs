using UnityEngine;

public class HealingSalve : Item {

    public override void Activate() {
        Debug.Log(gameObject.name + " лечится");
    }

    public override void DeActivate() {}

    public override void GetInfo() {}

}