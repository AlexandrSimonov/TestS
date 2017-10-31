using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour, IItem {

    public string itemName;
    public Texture sprite;
    public bool stacked; // Могут ли несколько одинаковых предметов данного типа стакаться
    // Вот это поле показывать если stacked == true;
    public int stackedMax;

    [HideInInspector]
    public int stackedNow;

    public float weight;

    public enum ItemType {
        Consumbles,
        Weapons
    }

    public ItemType type;

    public abstract void GetInfo();

    public abstract void Activate();

    public abstract void DeActivate();

    public static bool operator ==(Item item1, Item item2) {
        return item1.itemName == item2.itemName;
    }

    public static bool operator !=(Item item1, Item item2) {
        return item1.itemName != item2.itemName;
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }

    public override bool Equals(object obj) {
        var item = obj as Item;
        return item != null &&
               base.Equals(obj);
    }
}
