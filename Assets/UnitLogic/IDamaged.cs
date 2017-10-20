using UnityEngine;
using System.Collections;

public interface IDamaged {
    void Hit(float damage, DamageType type);
}
