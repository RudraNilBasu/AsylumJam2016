using UnityEngine;
using System.Collections;

public class tapWaterTrigger : MonoBehaviour {

    int doOnce = 0;

    int count = 0;
    // Use this for initialization

    [SerializeField]
    GameObject tapWater;

    float waitingTime = 8.0f; // it was 10.0f
        
    void OnTriggerEnter(Collider coll)
    {
        if (doOnce==0 && coll.tag == "Player") {
            doOnce++;
            callTrigger();
        }
    }

    public void callTrigger()
    {
        count++;
        if (count <= 3)
        {
            StartCoroutine(Trigger());
        }
        else {
            tapWater.GetComponent<tapWater>().itsOver();
        }
    }

    IEnumerator Trigger()
    {
        yield return new WaitForSeconds(waitingTime);
        // turn tap on
        tapWater.GetComponent<tapWater>().turnOn();
        //StartCoroutine(Trigger(no+1));
    }
}
