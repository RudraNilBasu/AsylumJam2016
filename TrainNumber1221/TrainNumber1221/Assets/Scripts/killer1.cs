using UnityEngine;
using System.Collections;

public class killer1 : MonoBehaviour {
    int doOnce = 0;
    [SerializeField]
    GameObject killer2;

    [SerializeField]
    GameObject bulb, bulbLight;

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
            bulb.SetActive(true);
            bulbLight.SetActive(true);
            bulbLight.GetComponent<Animation>().Play("lightFlicker_2");
            killer2.SetActive(true);
        }
    }
}
