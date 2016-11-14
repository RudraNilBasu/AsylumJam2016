using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class peopleInteract : MonoBehaviour {
    [SerializeField]
    Text quote;

    int doOnce = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (doOnce == 0 && coll.tag == "Player") {
            doOnce++;
            quote.text = "Man 1: One of the passenger is missing from Train number 1221.......";
            StartCoroutine(delay());
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3.0f);
        quote.text = "Man 2: The door of that unit was open when it reached the platform.......";
        yield return new WaitForSeconds(3.0f);
        quote.text = "";
    }
}
