using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTaskHandler : MonoBehaviour {
    public GameObject[] Node = new GameObject[10];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnNode(GameObject node_from ,GameObject node_to)
    {
        node_from.SetActive(false);
        node_to.SetActive(true);
    }
}
