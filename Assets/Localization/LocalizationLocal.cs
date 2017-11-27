using UnityEngine;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class LocalizationLocal {
    public string localName;

    [HideInInspector]
    public Dictionary<string, string> dictionary = new Dictionary<string, string>();

    public void Init() {
        dictionary.Clear();
        LoadLocal();
    }

    // Учаток кода нужндается в тестировании на различных устройствах из возможных проблем с инными от виндовс ОС
    private void LoadLocal() {
        try {
            string pathFolder = UtilFunction.PathCombine(new string[] {
                "Assets",
                "Resources",
                "L10n",
                localName
            });

            string[] files = Directory.GetFiles(pathFolder, "*.json");

            foreach (string file in files) {
                try {
                    string text = File.ReadAllText(file, Encoding.UTF8);


                    foreach (KeyValuePair<string, string> st in JsonConvert.DeserializeObject<Dictionary<string, string>>(text)) {
                        // Вот тут стоит уточнить, чтобы не было файлов с непонятными именами, нужно уточнять, что точки в инменах лучше не ставить
                        dictionary.Add(Path.GetFileNameWithoutExtension(file) + "." + st.Key, st.Value);
                    }

                } catch (JsonException e2) {
                    // Вот тут может быть конект с каким-то баг трекером
                    Debug.Log(e2.Message.ToString());
                }
            }


        } catch (IOException e) {
            Debug.Log(e.Message);
        }
    }
}