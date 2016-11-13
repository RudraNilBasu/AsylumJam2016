using UnityEngine;
using System.Collections;

public class silentDoorClose : MonoBehaviour {
    int doOnce = 0;


    [SerializeField]
    GameObject ghostDoor;
    
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
            ghostDoor.GetComponent<ghostDoor>().CloseDoor();
        }
    }
}
