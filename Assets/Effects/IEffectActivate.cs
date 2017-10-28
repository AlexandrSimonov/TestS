using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public interface IEffectActivate{
    

    IEffectActivate InitInActivate ();

    bool EffectLoop();

    void EffectUpdate(); // Цикл эффекта, возвращает true если время иссякло

    void EffectInit();
}
