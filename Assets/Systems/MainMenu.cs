using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Window loadWindow;
    public Text loadProgress;
    private AsyncOperation loadScene;

    public void SinglePlay() {
        loadWindow.Open();
        loadScene = SceneManager.LoadSceneAsync("s");
    }

    public void Exit() {
        Application.Quit();
    }

    private void Update() {
        if (loadScene != null) {
            loadProgress.text = Mathf.FloorToInt(loadScene.progress * 100) + "%";
        }
    }

}
