using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public interface IEffectActivate{
    

    //IEffectActivate InitInActivate (); // Переименовать

    bool EffectLoop(); // Цикл который определяет, закончилось ли событие

    void EffectUpdate(); // Цикл эффекта, возвращает true если время иссякло

    void OnInitEffect(); // "Событие", которое вызывается после иницилизации объекта
}
