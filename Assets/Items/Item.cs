using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour, IItem, IActivated{

    public string itemName;
    public Texture sprite;
    public bool stacked; // Могут ли несколько одинаковых предметов данного типа стакаться
    // Вот это поле показывать если stacked == true;
    public int stackedMax;

    [HideInInspector]
    public int stackedNow;

    public float weight;

    public abstract void GetInfo();

    public abstract void Activate(GameObject target);

    public abstract void DeActivate();
}
