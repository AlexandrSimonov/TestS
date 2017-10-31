using UnityEngine;

public class ItemInGrid : MonoBehaviour {

    public GameObject ItemName;
    public GameObject ActivityPanel;

    public void OpenActivityPanel() {
        ActivityPanel.SetActive(true);
    }

    public void CloseActivityPanel() {
        ActivityPanel.SetActive(false);
    }

    public void ShowItemName() {
        ItemName.SetActive(true);
    }

    public void HideItemName() {
        ItemName.SetActive(false);
    }
}
