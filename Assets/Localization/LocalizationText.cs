using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class LocalizationText : MonoBehaviour {

    public string Key;

    private void Start() {
        //Debug.Log("text");
        GetComponent<Text>().text = Localization.GetWord(Key);
    }

    private void Update() {
        GetComponent<Text>().text = Localization.GetWord(Key);
    }
}
