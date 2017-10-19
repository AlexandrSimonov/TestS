using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsActive : MonoBehaviour {

    private List<IEffect> Effects;

	void Start() {
        Effects = new List<IEffect>();

        AddEffect(new RegenHp(4, this.gameObject, 20));
	}

    public void AddEffect(IEffect effect) {
        Effects.Add(effect);
    }

    void Update() {
        for (int i = 0; i < Effects.Count; i++) {
            if (Effects[i].GetTimeEnd() <= Time.time) {
                Effects.RemoveAt(i);
            } else {
                Effects[i].Update();
            }           
        }
    }
}
