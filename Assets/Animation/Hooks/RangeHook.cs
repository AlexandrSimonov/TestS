using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeHook : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Hook");

        Destroy(this);
	}
}
