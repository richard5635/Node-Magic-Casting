using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTaskHandler : MonoBehaviour {
    GameObject magicCircle;

    List<int> TaskSequence = new List<int>();
    public GameObject[] Node = new GameObject[10];
    public GameObject MagicCircleShoot;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CastSpell(GameObject obj)
    {

    }

    void ActivateNode(GameObject node)
    {
        node.GetComponent<SphereCollider>().enabled = true;
        for(int i = 0; i < node.transform.childCount; i++)
        {
            node.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void DeactivateNode(GameObject node)
    {
        node.GetComponent<SphereCollider>().enabled = false;
        for (int i = 0; i < node.transform.childCount; i++)
        {
            node.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void SpawnNode(GameObject node_from, GameObject node_to)
    {
        DeactivateNode(node_from);
        ActivateNode(node_to);
    }
}
