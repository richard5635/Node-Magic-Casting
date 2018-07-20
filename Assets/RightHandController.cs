using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandController : MonoBehaviour {
    GameObject moCon;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moCon = GameObject.Find("RightController");
        if (moCon != null)
        {
            transform.position = moCon.transform.position;
        }
    }
}
