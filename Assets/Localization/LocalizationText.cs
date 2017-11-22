using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LocalizationText : MonoBehaviour {

    public string Key;
    private Text field;
    private void Start() {
        //Debug.Log("text");
        field = GetComponent<Text>();

        Changed();

        Localization.GetOnChangeLocale().AddListener(Changed);
    }

    private void Changed() {
        field.text = Localization.GetWord(Key);
    }
}
