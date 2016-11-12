using UnityEngine;
using System.Collections;

public class doorLockerTrigger : MonoBehaviour {

    [SerializeField]
    GameObject doorLocker;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player") {
            doorLocker.SetActive(true);
        }
    }
}
