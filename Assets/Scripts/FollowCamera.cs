using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    public Transform MainCamera_T;
    Vector3 initPos;
    Vector3 initRot;
	// Use this for initialization
	void Awake () {
        initPos = transform.position;
        initRot = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position =  MainCamera_T.position - initPos;
        transform.eulerAngles = MainCamera_T.eulerAngles;
    }
}
