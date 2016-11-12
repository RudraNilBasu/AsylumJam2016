using UnityEngine;
using System.Collections;

public class doorLocker : MonoBehaviour {
    int doOnce = 0;
    [SerializeField]
    GameObject theDoor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (doOnce==0 && coll.tag == "Player")
        {
            doOnce++;
            // Lock the Door
            theDoor.GetComponent<Door>().lockDoor();
        }
    }
}
