using UnityEngine;
using UnityEngine.UI;

public class ThrowPanel : MonoBehaviour{

    public Slider slider;
    public Text countText;

    private ItemInInventory item;
    private int value;

    void Start() {
        slider.onValueChanged.AddListener(delegate { ValueChanged(); });
    }

    public void Open(ItemInInventory item) {
        slider.maxValue = item.count;
        value = 1;

        if (item.item.stacked) {
            slider.gameObject.SetActive(true);
            countText.gameObject.SetActive(true);    
        } else {
            slider.gameObject.SetActive(false);
            countText.gameObject.SetActive(false);
        }

        this.item = item;

        gameObject.SetActive(true);
    }

    private void Update() {
        slider.value = value;
    }

    public void ValueChanged() {
        countText.text = "" + slider.value;
        value = (int)slider.value;
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void Okay() {
        item.ThrowObject((int)this.slider.value);
        Close();
    }
}
