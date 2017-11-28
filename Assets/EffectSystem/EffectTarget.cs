using UnityEngine;
using System.Collections.Generic;

// Висит на том, кто под действием эффекта
public class EffectTarget : MonoBehaviour {

    public List<Effect> effects;

    public void AddEffect(Effect effect) {
        effects.Add(effect);
        effect.Init(this);
        effect.Start();
    }

    public void RemoveEffect() {

    }

    private void Update() {
        for (int i = 0; i < effects.Count; i++) {
            effects[i].Update();
        }
    }

    public void Delete(Effect effect) {
        effects.Remove(effect);
        Debug.Log("Delete");
    }
}
