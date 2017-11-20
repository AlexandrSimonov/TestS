using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerController : MonoBehaviour {

    private IAttack attack;
	// Use this for initialization
	void Start () {
        attack = GetComponent<IAttack>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
