using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandController : MonoBehaviour {
    GameObject moCon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moCon = GameObject.Find("LeftController");
        if(moCon != null)
        {
            transform.position = moCon.transform.position;
        }
	}
}
