using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour {
    public GameObject AE_Fire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.forward * 0.05f;
	}
    private void OnTriggerEnter(Collider col)
    {
        Instantiate(AE_Fire, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
