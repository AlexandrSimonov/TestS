using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

public class LocalizationWindowEditor : EditorWindow {

    // Создание ключа
    private string key = "";
    private int sectionID = 0;
    private List<string> sections = new List<string>();

    // Создание секции
    private string sectionName = "";

    public void OnEnable() {
        GetSections();
    }

    private void GetSections() {
        // Вот эта штука не будет работать если не будет, английского языка
        string pathFolder = UtilFunction.PathCombine(new string[] {
                "Assets",
                "Resources",
                "L10n",
                "EN"
            });

        sections.Clear();

        string[] __sections = Directory.GetFiles(pathFolder, "*.json");

        for (int i = 0; i < __sections.Length; i++) {
            sections.Add(Path.GetFileNameWithoutExtension(__sections[i]));
        }
    }

    [MenuItem("Window/Localization")]
    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(LocalizationWindowEditor));
    }

    void OnGUI() {
        NewKeyGUI();

        NewSectionGUI();
    }

    private void NewSectionGUI() {
        GUILayout.Label("Создание новой секции", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Введите название секции");

        sectionName = GUILayout.TextField(sectionName);

        if (GUILayout.Button("Новая секция", EditorStyles.miniButtonRight)) {
            NewSection();
        }

        GUILayout.EndHorizontal();
    }

    private void NewKeyGUI() {
        GUILayout.Label("Создание нового ключа", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Выберите секцию и введите ключ");

        GUIContent[] content = new GUIContent[sections.Count];

        for (int i = 0; i < sections.Count; i++) {
            content[i] = new GUIContent(sections[i]);
        }

        sectionID = EditorGUILayout.Popup(sectionID, content);

        key = GUILayout.TextField(key);

        if (GUILayout.Button("Добавить", EditorStyles.miniButtonRight)) {
            NewKey();
        }

        GUILayout.EndHorizontal();
    }

    private void NewKey() {
        // Вот тут будет добавление в локализационные файлы
        string pathFolder = UtilFunction.PathCombine(new string[] {
                "Assets",
                "Resources",
                "L10n"
            });

        string[] locales = Directory.GetDirectories(pathFolder);

        foreach (string locale in locales) {
            string fileName = Path.Combine(locale, sections[sectionID] + ".json");
            string text = File.ReadAllText(fileName, Encoding.UTF8);

            Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);

            dictionary.Add(key, "");

            File.WriteAllText(fileName, JsonConvert.SerializeObject(dictionary, Formatting.Indented), Encoding.UTF8);

        }

        key = "";
        sectionID = 0;
    }

    private void NewSection() {
        string pathFolder = UtilFunction.PathCombine(new string[] {
                "Assets",
                "Resources",
                "L10n"
            });

        string[] locales = Directory.GetDirectories(pathFolder);

        foreach (string locale in locales) {
            FileStream stream = File.Create(Path.Combine(locale, sectionName + ".json"));
            // Нужно сюда записать {}
            stream.Close();
        }


        sectionName = "";
        GetSections();
    }


}
