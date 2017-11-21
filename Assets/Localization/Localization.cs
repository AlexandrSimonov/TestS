using UnityEngine;
using System.Collections.Generic;


/*
 Надо где-то описывать правила
 
 Файлы локализации должны быть ТОЛЬКО в формате UTF-8

 Файл в названии недолжен содеражать пробелы или точки

 Если нужно использовать несколько слов, то используем CamelCase

 Названия ключа должно быть без спец символов и точек

 
*/
[ExecuteInEditMode]
public class Localization : MonoBehaviourSingelton<Localization> {

    public LocalizationLocal[] locales;
    public LocalizationLocal current = null;
    // Если локаль не используется, то для неё очищаем словарь, чтобы не занимать ОЗУ
    private void Start() {
        foreach (LocalizationLocal local in locales) {
            local.Init();
        }

        if (locales[0] != null) {
            current = locales[0];
        }

        Debug.Log("123");
    }

    // ПРотестируем если в ключе два пробела, нет пробелов и т.д
    private static string GetWordFromKey(string key) {
        string[] words = key.Split(new char[] { '.' });

        if (words.Length == 2) {
            return words[1];
        }

        Debug.LogWarning("Данный ключ не может быть заменен строкой");

        return "";
    }

    public static string GetWord(string key) {
        string value = "";

        foreach (KeyValuePair<string, string> pair in Instance.current.dictionary) {
            Debug.Log(pair.Key + " "  + pair.Value);
        }

        if (Instance.current.dictionary.TryGetValue(key, out value)) {
            return value;
        } else {
            Debug.LogWarning("Такой ключ не был найден. Проверьте название секции и ключа");
            return GetWordFromKey(key);
        }
    }
}
