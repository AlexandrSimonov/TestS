using UnityEngine;
using System.Collections;

public class ItemStack : MonoBehaviour, ICatchItem {

    public Item item;
    public int count;

    public void Catch(Inventory inventory) {
        int i = 0;
        while (i < count) {
            inventory.AddItem(item);
            i++;
        } 
    }
}
