using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearBehaviour : MonoBehaviour {
    public float duration = 8.0f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, duration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
