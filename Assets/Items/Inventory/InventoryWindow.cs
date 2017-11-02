using UnityEngine;
using System.Collections;

public class InventoryWindow : ItemWindow {

    public Transform parentForObject;
    public Inventory inventory;
    public GameObject prefabObj;

    // Вот в этих классах скрываем магию того как окна отображают свои элементы и т.д
    // Вот в этих окнах выбираем префабы и настраиваем отображание как нужно
    void Start() {
        inventory.InventoryChange.AddListener(View); 
    }

    public void View() {
        // Вот тут контролируется всё, чтобы было четенько и об]екты создавались нужные в нужном количестве
        foreach (ItemInInventoryStructure obj in inventory.GetItems()) {
            ItemInInventory itemInInventory = Instantiate(prefabObj, parentForObject).GetComponent<ItemInInventory>();
            itemInInventory.Init(obj);
        }
    }


}
