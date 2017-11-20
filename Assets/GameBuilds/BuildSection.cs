using UnityEngine;
using System.Collections;

public class BuildSection : MonoBehaviour {

    public GameObject obj;
    public bool isEmpty = true;
    private MeshRenderer mesh;

    public Material activateMaterial;
    public Material defaultMaterial;
    public Material tempMaterial;

    private void Awake() {
        mesh = GetComponent<MeshRenderer>();
    }

    public void TempActivate() {
        mesh.material = tempMaterial;
    }

    public void Activate() {
        mesh.material = activateMaterial;
    }

    public void Default() {
        if (isEmpty) {
            mesh.material = defaultMaterial;
        } else {
            mesh.material = activateMaterial;
        }
        
    }

    public void SetEmpty(bool value) {
        isEmpty = value;

        Default();
    }
}
