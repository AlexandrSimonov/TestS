using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToolTip : MonoBehaviour {

    private GameObject item;
    

    public void Activate(GameObject item) {
        gameObject.SetActive(true);
        Debug.Log(item);
        this.item = Instantiate(item, this.transform);
        this.item.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
        this.item.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
        this.item.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
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
