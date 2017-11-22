using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

/*
 Надо где-то описывать правила
 
 Файлы локализации должны быть ТОЛЬКО в формате UTF-8

 Файл в названии недолжен содеражать пробелы или точки

 Если нужно использовать несколько слов, то используем CamelCase

 Названия ключа должно быть без спец символов и точек
*/

/*
 При реализации, мы будем использовать гит для хранения переводов, то есть отдельная ветка в которую можно будет делать переводики
*/

public class Localization : MonoBehaviourSingelton<Localization> {

    public LocalizationLocal[] locales;
    public LocalizationLocal current = null;

    public UnityEvent OnChangeLocale;

    // Если локаль не используется, то для неё очищаем словарь, чтобы не занимать ОЗУ
    private void Start() {
        InitLocales();

        if (locales[0] != null) {
            current = locales[0];
        }
    }

    [ContextMenu("Инициализация локалей")]
    private void InitLocales() {
        // Тут стоит сделать проверку, чтобы не было одинаковых локалей двух

        foreach (LocalizationLocal local in locales) {
            local.Init();
        }
    }

    public static void ChangeLocale(int index) {
        Instance.current = null;
        if (Instance.locales[index] != null) {
            Instance.current = Instance.locales[index];
        }

        if (Instance.current == null) {
        //Значит локаль не найдена, нужна ошибка
        }

        Instance.OnChangeLocale.Invoke();
    }

    public static string[] GetLocalNames() {
        string[] names = new string[Instance.locales.Length];

        for (int i = 0; i < Instance.locales.Length; i++) {
            names[i] = Instance.locales[i].localName;
        }

        return names;
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
        string value;

        if (Instance.current.dictionary.TryGetValue(key, out value)) {
            return value;
        } else {
            Debug.LogWarning("Такой ключ не был найден. Проверьте название секции и ключа");
            return GetWordFromKey(key);
        }
    }

    public static UnityEvent GetOnChangeLocale() {
        return Instance.OnChangeLocale;
    }

}
