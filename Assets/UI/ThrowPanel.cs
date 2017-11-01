using UnityEngine;
using UnityEngine.UI;

public class ThrowPanel : MonoBehaviour{

    public Slider slider;
    public Text countText;

    private ItemInInventory item;
    private int value;

    private static ThrowPanel instance;

    private void Awake() {
        slider.onValueChanged.AddListener(delegate { ValueChanged(); });

        instance = this;

        gameObject.SetActive(false);
    }

    public static void Open(ItemInInventory item) {
        instance.slider.maxValue = item.count;
        instance.value = 1;

        if (item.item.stacked) {
            instance.slider.gameObject.SetActive(true);
            instance.countText.gameObject.SetActive(true);    
        } else {
            instance.slider.gameObject.SetActive(false);
            instance.countText.gameObject.SetActive(false);
        }

        instance.item = item;

        instance.gameObject.SetActive(true);
    }

    private void Update() {
        slider.value = value;
    }

    public void ValueChanged() {
        countText.text = "" + slider.value;
        value = (int)slider.value;
    }

    public static void Close() {
        instance.gameObject.SetActive(false);
    }

    public void Okay() {
        item.ThrowObject((int)this.slider.value);
        Close();
    }
}
