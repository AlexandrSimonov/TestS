using UnityEngine;
using System.Collections;

public class StartButtonController : MonoBehaviour {

    public void Hide() {
        transform.gameObject.SetActive(false);
    }

    public void Show() {
        transform.gameObject.SetActive(true);
    }
}
