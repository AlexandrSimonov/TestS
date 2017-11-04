using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public abstract class Item : MonoBehaviour, IItem, ICatchItem {
    
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
    /*Для айтемов нужно будет писать какую-то штуку для сравнения*/
    public void Catch(Inventory inventory) {
       // inventory.AddItem(this);
    }

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

    public Item GetCopy() {
        return MemberwiseClone() as Item;
    }


    public abstract void GetInfo();

    public abstract void Activate();

    public abstract void DeActivate();

    
}
