using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenHp : IEffect {

    private float timeEnd = 0;
    private float regen = 0;
    private Hp hp;

    public RegenHp(float duration, GameObject obj, float regen) {
        this.timeEnd = Time.time + duration;
        this.regen = regen;
        this.hp = obj.GetComponent<Hp>();
    }

	public void Update () {
        hp.Plus(regen * Time.deltaTime);
	}

    public float GetTimeEnd() {
        return timeEnd;
    }
}
