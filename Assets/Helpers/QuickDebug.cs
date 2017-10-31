using UnityEngine;
using System.Collections;

public class QuickDebug : MonoBehaviour {

    public Inventory inventory;
    public Shop shop;

    
    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            inventory.ChangeWindowState();
            shop.CloseWindow();
        }

        if (Input.GetKeyDown(KeyCode.O)) {
            shop.ChangeWindowState();
            inventory.CloseWindow();
        }
    }
}
