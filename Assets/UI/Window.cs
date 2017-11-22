using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

// Компонент, который должен получать объект, который хочет вести себя как окно
public class Window : MonoBehaviour {

    public KeyCode hotkey; // Горячая клавиша для открытия или закрытия окна
    public GameObject mask; // Маска (если нужна), чтобы не было возможности клацнуть за окном по сцене
    public GameObject window; // Ссылка на само окно

    public bool isOpened = true;

    private void Start() {
        StateChange();
    }

    void Update() {
        if (Input.GetKeyDown(hotkey)) {
            isOpened = !isOpened;

            StateChange();
        }
    }

    [ContextMenu("Close")]
    public void Close() {
        isOpened = false;
        StateChange();
    }

    [ContextMenu("Open")]
    public void Open() {
        isOpened = true;
        StateChange();
    }

    private void StateChange() {
        mask.SetActive(isOpened);
        window.SetActive(isOpened);
    }
}
