using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeHandler : MonoBehaviour {
    public GameObject NTrigger;
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
        
        if(other.gameObject.name == "HandL" || other.gameObject.name == "HandR")
        {
            switch(NodeId)
            {
                case 1:
                    GetComponent<AudioSource>().Play(); //Sound will not play if deactivated suddenly.
                    taskHandler.SpawnNode(gameObject, taskHandler.Node[NodeId + 1]);
                    taskHandler.ActivateNode(taskHandler.Node[NodeId + 2]);
                    break;
                case 2:
                    nodeWait = NodeWaitingTime(taskHandler.MagicCircleShoot);
                    StartCoroutine(nodeWait);
                    break;
                case 3:
                    nodeWait = NodeWaitingTime(taskHandler.MagicCircleAppear);
                    StartCoroutine(nodeWait);
                    taskHandler.MagicCircleAppear.GetComponent<MagicCastingHandler>().Cast(taskHandler.MagicCircleAppear.GetComponent<MagicCastingHandler>().Waterfall);
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

    IEnumerator NodeWaitingTime(GameObject obj)
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
        Instantiate(NTrigger, transform);
        taskHandler.SpawnNode(gameObject, obj);
        yield return null;
    }

    
}
