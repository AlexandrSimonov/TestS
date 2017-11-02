using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemDescription : MonoBehaviour {

    public Text _textField;
    public RawImage _imageField;
    public Text _description;
    public Transform _activityPanel;
    public GameObject _activityBtn;

    /*
    Подумать как убрать генерацию кнопок
    Обновления состояния
    */
    public void Open(ItemInGrid item) {
        
    }

    public void Close() {
        //instance.gameObject.SetActive(false);
    }
}
