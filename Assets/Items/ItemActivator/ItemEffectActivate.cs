using UnityEngine;
using System.Collections;

public class ItemEffectActivate : Item {

    public override void Activate() {
        IEffect[] effects = GetComponents<IEffect>();

        foreach (IEffect effect in effects) {
            effect.InitEffect(Owner.GetComponent<EffectActivate>());
        }
    }

    public override void DeActivate() { }

    public override void GetInfo() { }
}
