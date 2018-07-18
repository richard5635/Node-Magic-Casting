using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeHandler : MonoBehaviour {
    public int NodeId = 1;
    MagicTaskHandler taskHandler;
    TextMeshProUGUI nodeIdText;
    TextMeshProUGUI textMesh;

    Collider selectedNode;

    IEnumerator nodeWait;

    private void Awake()
    {
        taskHandler = GameObject.Find("Player").GetComponent<MagicTaskHandler>();
    }

    private void Start()
    {
        nodeIdText = transform.Find("NodeNumber").GetComponent<TextMeshProUGUI>();
        nodeIdText.text = NodeId.ToString();
        textMesh = transform.Find("CastingTime").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        selectedNode = other;
        nodeWait = NodeWaitingTime();
        if(other.gameObject.name == "HandL" || other.gameObject.name == "HandR")
        {
            switch(NodeId)
            {
                case 1:
                    GetComponent<AudioSource>().Play(); //Sound will not play if deactivated suddenly.
                    taskHandler.SpawnNode(gameObject, taskHandler.Node[NodeId + 1]);
                    break;
                case 2:
                    StartCoroutine(nodeWait);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(selectedNode == other)
        {
            StopCoroutine(nodeWait);
        }
        
    }

    IEnumerator NodeWaitingTime()
    {
        //float time = 0;
        //while(time < 1)
        //{
        //    textMesh.text = time.ToString("F2");
        //    time += Time.deltaTime;
        //yield return null;
        //}
        Debug.Log("entered second node");
        GetComponent<AudioSource>().Play();
        taskHandler.SpawnNode(gameObject, taskHandler.MagicCircleShoot);
        yield return null;
    }

    
}
