using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    public float duration = 2.0f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, duration);
	}
	
}
