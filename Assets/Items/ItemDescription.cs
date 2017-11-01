using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemDescription : MonoBehaviour {

    public Text _textField;
    public RawImage _imageField;
    public Text _description;
    public Transform _activityPanel;
    public GameObject _activityBtn;

    private static ItemDescription instance;

    void Awake() {
        instance = this;
        instance.gameObject.SetActive(false);
    }

    public static void Open(ItemInGrid item) {
        instance.gameObject.SetActive(true);
        instance._textField.text = item.item.itemName;
        instance._imageField.texture = item.item.sprite;

        instance._description.text = item.GenerateDescription();

        foreach (Transform child in instance._activityPanel.transform) {
            Destroy(child.gameObject);
        }

        foreach (ItemInGrid.ActivityButton actBtn in item.GenerateActivityButton()) {
            GameObject GO = Instantiate(instance._activityBtn, instance._activityPanel);
            GO.GetComponent<Button>().onClick.AddListener(actBtn.btnEvent);
            GO.transform.GetChild(0).GetComponent<Text>().text = actBtn.btnName;
        }
    }

    public static void Close() {
        //instance.gameObject.SetActive(false);
    }
}
