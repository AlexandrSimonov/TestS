using UnityEngine;
using System.Collections;

public class Wrapper : MonoBehaviour {

    public GameObject obj;

    public GameObject SetGameObject (GameObject obj) {
        Instantiate(obj, transform);
        this.obj = obj;
        return this.obj;
    }
}
