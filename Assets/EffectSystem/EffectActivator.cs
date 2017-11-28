using UnityEngine;
using System.Collections.Generic;

//Висит на том, кто набрасывает эффект
public class EffectActivator : MonoBehaviour {

    public List<Effect> Effects;

    [ContextMenu("Activate")]
    public void DebugEffect() {
        foreach (Effect effect in Effects) {
            GetComponent<EffectTarget>().AddEffect(effect.CloneEffect());
        }
    }


    public void ActivateAllEffect(EffectTarget target) {
        foreach (Effect effect in Effects) {
            target.AddEffect(effect.CloneEffect());
        }
    }

    public void ActivateEffectId(EffectTarget target, int id) {
        target.AddEffect(Effects[id].CloneEffect());
    }
}
