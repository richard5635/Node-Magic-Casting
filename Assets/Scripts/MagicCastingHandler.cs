using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCastingHandler : MonoBehaviour {
    public GameObject[] Spells = new GameObject [1];
    public GameObject MCTrigger;
    Collider selectedNode;
    public int CircleId = 1;
    bool isBusy = false;
    bool triggerSwitch = false;

    //
    //Shoot
    //
    public GameObject Fire;
    public GameObject Snow;
    public GameObject Waterfall;

    IEnumerator castTime;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerSwitch) return;
        selectedNode = other;//remove this if you want the casting time to accumulate even if you leave your hands off.
        castTime = CastingTime();
        if ((other.gameObject.name == "HandL" || other.gameObject.name == "HandR"))
        {
            isBusy = true;
            StartCoroutine(castTime);
        }
        triggerSwitch = true;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerSwitch = false;
        if(other == selectedNode)
        {
            isBusy = false;
            StopCoroutine(castTime);
        }
    }

    public void Cast(GameObject spell)
    {
        Instantiate(spell);
    }

    IEnumerator CastingTime()
    {
        Debug.Log("Entered Magic Circle");
        GetComponent<AudioSource>().Play();
        Instantiate(MCTrigger, new Vector3(transform.position.x, transform.position.y, transform.position.z -0.2f), Quaternion.identity, transform);
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            yield return null;
        }
        Cast(Fire);
        isBusy = false;
    }
}
