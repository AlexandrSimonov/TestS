using UnityEngine;
using System.Collections;

public class Damaged : MonoBehaviour, IDamaged {
    
    // Тут описывается соправтивление разным типам урона

    public float physic;
    public float magic;

    public void Hit(float damage, DamageType type) {
        if (type == DamageType.Physic) {
            Damage(PhysicDamage(damage));
        } else if (type == DamageType.Magic) {
            Damage(MagicDamage(damage));
        } 
    }

    protected void Damage(float damage) {
        GetComponent<Hp>().Minus(damage);
    }

    protected float PhysicDamage(float damage) {
        return (1 - physic / 100) * damage;
    }

    protected float MagicDamage(float damage) {
        return (1 - magic / 100) * damage;
    }


}
