using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class QuickMenu : MonoBehaviour {
    public void ExitInMenu() {
        SceneManager.LoadScene("Menu");
    }
}
