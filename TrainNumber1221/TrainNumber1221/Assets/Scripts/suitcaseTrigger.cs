using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class suitcaseTrigger : MonoBehaviour {
    int doOnce = 0;
    float waitingTime = 5.0f;

    [SerializeField]
    Text quote;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (doOnce == 0 && coll.tag == "Player")
        {
            doOnce++;
            quote.text = "Where is my bag ?";
            StartCoroutine(turnOff());
        }
    }
    IEnumerator turnOff()
    {
        yield return new WaitForSeconds(waitingTime);
        quote.text = "";
    }
}
