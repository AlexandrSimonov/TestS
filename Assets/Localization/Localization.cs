using UnityEngine;
using UnityEngine.Events;

/*
 Надо где-то описывать правила
 
 Файлы локализации должны быть ТОЛЬКО в формате UTF-8

 Файл в названии недолжен содеражать пробелы или точки

 Если нужно использовать несколько слов, то используем CamelCase

 Названия ключа должно быть без спец символов и точек
*/

/* 
 Поставил под сомнения
 При реализации, мы будем использовать гит для хранения переводов, то есть отдельная ветка в которую можно будет делать переводики
*/

/*
 Стоит сделать параметизированную локализацию, чтобы можно было подставлять в текст слова и другие ключи в качестве парамметра  
*/

[CreateAssetMenu(fileName = "Localization", menuName = "SingletonCreate/Localization", order = 1)]
public class Localization : ScriptableObjectSingleton<Localization> {

    public LocalizationLocal[] locales;
    private LocalizationLocal current = null;

    public string currentLocale;

    [HideInInspector]
    public UnityEvent OnChangeLocale;

    // Если локаль не используется, то для неё очищаем словарь, чтобы не занимать ОЗУ

    public override void Init() {
        Debug.Log(" Localization Init");

        InitLocales();

        string locale = PlayerPrefs.GetString("locale");
        Debug.Log(locale);
        if (locale != "") {
            ChangeLocale(locale);
        } else {
            ChangeLocale(currentLocale);
        }
    }

    [ContextMenu("Инициализация локалей")]
    private void InitLocales() {
        // Тут стоит сделать проверку, чтобы не было одинаковых локалей двух

        foreach (LocalizationLocal local in locales) {
            local.Init();
        }
    }

    [ContextMenu("Сменить локаль в редакторе")]
    public void ChangeLocaleInEditor() {
        ChangeLocale(currentLocale);
    }


    public static void ChangeLocale(string name) {
        Instance.current = null;

        foreach (LocalizationLocal local in Instance.locales) {
            if (name == local.localName) {
                Instance.ChangeLocaleA(local);
            }
        }

        Instance.OnChangeLocale.Invoke();
    }

    private void ChangeLocaleA(LocalizationLocal local) {
        Instance.current = local;
        Instance.currentLocale = local.localName;
        PlayerPrefs.SetString("locale", local.localName);
    }

    public static void ChangeLocale(int index) {
        Instance.current = null;
        if (Instance.locales[index] != null) {
            Instance.ChangeLocaleA(Instance.locales[index]);
        }

        if (Instance.current == null) {
            //Значит локаль не найдена, нужна ошибка
        }

        Instance.OnChangeLocale.Invoke();
    }

    public static string GetCurrentLocale() {
        return Instance.currentLocale;
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
            Debug.LogWarning("Такой ключ(" + key + ") не был найден. Проверьте название секции и ключа");
            return GetWordFromKey(key);
        }
    }

    public static UnityEvent GetOnChangeLocale() {
        return Instance.OnChangeLocale;
    }

}
