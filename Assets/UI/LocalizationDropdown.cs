using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

//
// Подмуть над своей коллекцией кастомных ui компонентов, иногда дефолтные тупят
// 
public class LocalizationDropdown : MonoBehaviour {

    private Dropdown dropdown;

    void Start() {
        dropdown = GetComponent<Dropdown>();
        InitDropdown();
    }


    private void InitDropdown() {
        dropdown.ClearOptions();

        List<Dropdown.OptionData> dropdownObj = new List<Dropdown.OptionData>();

        foreach (string name in Localization.GetLocalNames()) {
            dropdownObj.Add(new Dropdown.OptionData(name));
        }

        dropdown.AddOptions(dropdownObj);

        dropdown.onValueChanged.AddListener(Localization.ChangeLocale);
    }


    private void OnDestroy() {
        dropdown.onValueChanged.RemoveListener(Localization.ChangeLocale);
    }
}
