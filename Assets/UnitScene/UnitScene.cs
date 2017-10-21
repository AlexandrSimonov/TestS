using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitScene : MonoBehaviour {

    public GameObject[] objects;

    public Button attack;
    public Button damaged;

    public GameObject enemie;

    // Use this for initialization
    void Start() {
        foreach (GameObject obj in objects) {

            GameObject gameObj = Instantiate(obj, transform);
            
            RotateLocal rotLoc = gameObj.GetComponent<RotateLocal>();

            gameObj.SetActive(false);

            if (rotLoc != null) {
                rotLoc.enabled = false;
            }

        } 
    }

    private GameObject unit;
    private bool block = false;
    // Update is called once per frame
    void Update() {

        attack.onClick.RemoveAllListeners();
        damaged.onClick.RemoveAllListeners();

        for (int i = 0; i < objects.Length; i++) {
            if (transform.GetChild(i).gameObject.activeSelf) {
                unit = transform.GetChild(i).gameObject;
                attack.onClick.AddListener(Hit);
                damaged.onClick.AddListener(Damage);
                break;
            }
        }
        
    }

    void Damage () {
        enemie.GetComponent<IAttack>().AttackUnit(unit);
    }

    void Hit() {
        unit.GetComponent<IAttack>().AttackUnit(enemie);
    }
}
