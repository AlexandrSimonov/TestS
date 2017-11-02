using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemDescription : MonoBehaviour {

    public Text _textField;
    public RawImage _imageField;
    public Text _description;
    public Transform _activityPanel;
    public GameObject _activityBtn;


    public void Open(ItemInGrid item) {
        gameObject.SetActive(true);
        _textField.text = item.item.itemName;
        _imageField.texture = item.item.sprite;

        _description.text = item.GenerateDescription();

        /* Подумать о том чтобы не удалять кнопки*/
        foreach (Transform child in _activityPanel.transform) {
            Destroy(child.gameObject);
        }

        foreach (ItemInGrid.ActivityButton actBtn in item.GenerateActivityButton()) {
            GameObject GO = Instantiate(_activityBtn, _activityPanel);
            GO.GetComponent<Button>().onClick.AddListener(actBtn.btnEvent);
            GO.transform.GetChild(0).GetComponent<Text>().text = actBtn.btnName;
        }
    }

    public void Close() {
        //instance.gameObject.SetActive(false);
    }
}
