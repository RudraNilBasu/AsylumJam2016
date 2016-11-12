using UnityEngine;
using System.Collections;

public class manCrying : MonoBehaviour {

    int doOnce = 0;
    

    [SerializeField]
    GameObject tapWaterTrigger;

	// Use this for initialization
	void Start () {
        doOnce = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag=="Player" && doOnce==0)
        {
            doOnce++;
            gameObject.GetComponent<AudioSource>().Play();
            tapWaterTrigger.SetActive(true);
            //StartCoroutine(Trigger());
        }
    }
    /*
    IEnumerator Trigger()
    {
        yield return new WaitForSeconds(waitingTime);
        
        // turn tap on
        tapWater.GetComponent<tapWater>().turnOn();
    }
    */
    
}
