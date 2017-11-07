using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToolTip : MonoBehaviour {

    private GameObject item;
     
    public void Activate(GameObject item) {
        gameObject.SetActive(true);
        this.item = Instantiate(item, this.transform, true);
        this.item.GetComponent<Image>().raycastTarget = false;
    }

    public void DeActivate() {
        Destroy(item);
    }

    void Update() {
        if (this.gameObject.activeSelf) {
            transform.position = Input.mousePosition;
        }
    }
}
