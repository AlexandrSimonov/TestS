using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

//
// Подмуть над своей коллекцией кастомных ui компонентов, иногда дефолтные тупят
// 
public class LocalizationDropdown : MonoBehaviour {

    private Dropdown dropdown;

    public Dictionary<string, string> languages = new Dictionary<string, string>();

    void Start() {
        dropdown = GetComponent<Dropdown>();

        languages.Add("RU", "Русский");
        languages.Add("EN", "English");

        InitDropdown();
    }


    private void InitDropdown() {
        dropdown.ClearOptions();

        List<Dropdown.OptionData> dropdownObj = new List<Dropdown.OptionData>();
        int value = -1;

        string[] names = Localization.GetLocalNames();
        for (int i = 0; i < names.Length; i++) {
            if (languages[names[i]] != null) {
                dropdownObj.Add(new Dropdown.OptionData(languages[names[i]]));

                if (names[i] == Localization.GetCurrentLocale()) {
                    value = i;
                }
            }

        }

        dropdown.AddOptions(dropdownObj);

        if (value != -1) {
            dropdown.value = value;
        }

        dropdown.onValueChanged.AddListener(Localization.ChangeLocale);
    }


    private void OnDestroy() {
        if (dropdown.onValueChanged != null) {
            dropdown.onValueChanged.RemoveListener(Localization.ChangeLocale);
        }
    }
}
