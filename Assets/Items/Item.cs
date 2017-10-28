using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour, IItem, IActivated{

    public string itemName;

    public abstract void GetInfo();

    public abstract void Activate(GameObject target);

    public abstract void DeActivate();
}
