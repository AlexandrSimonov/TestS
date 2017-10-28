using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public interface IEffectActivate{
    bool EffectUpdate(); // Цикл эффекта, возвращает true если время иссякло

    IEffectActivate InitInActivate (Type type);

    void EffectInit();
}
