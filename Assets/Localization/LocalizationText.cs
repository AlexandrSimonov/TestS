using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LocalizationText : MonoBehaviour {

    public string Key;
    private Text field;

    private void Start() {
        field = GetComponent<Text>();

        Changed();
        Localization.GetOnChangeLocale().AddListener(Changed);
    }

    public void SetKey(string key) {
        this.Key = key;
        Changed();
    }

    private void Changed() {
        field.text = Localization.GetWord(Key);
    }

    private void OnDestroy() {
        Localization.GetOnChangeLocale().RemoveListener(Changed);
    }
}
