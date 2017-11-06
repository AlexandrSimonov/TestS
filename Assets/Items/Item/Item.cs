using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public abstract class Item : MonoBehaviour, IItem {
    public string itemName;
    public Texture sprite;
    public GameObject model;

    public float weight;

    public GameObject Owner;

    public enum ItemType {
        Consumbles,
        Weapons
    }

    public ItemType type;

    public void SetOwner(GameObject Owner) {
        this.Owner = Owner;
    }

    public void SetItemName(string name) {
        itemName = name;
    }

    public void Change() {
        Debug.Log("Изменение debug");
    }

    public void CastSpell() {
        SetItemName(itemName + "(заколдованное)");
    }

    /*public static bool operator==(Item item1, Item item2) {
        Debug.Log(item1 + "" + item2);
        if (item1 == null || item2 == null) {
            return false;
        }

        return item1.itemName == item2.itemName;
    }

    public static bool operator !=(Item item1, Item item2) {
        if (item1 == null || item2 == null) {
            return false;
        }

        return item1.itemName != item2.itemName;
    }

    public override bool Equals(object item) {
        if (item == null) {
            return false;
        }
        return (item as Item) == this;
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }*/

    public abstract void GetInfo();

    public abstract void Activate();

    public abstract void DeActivate();
}
