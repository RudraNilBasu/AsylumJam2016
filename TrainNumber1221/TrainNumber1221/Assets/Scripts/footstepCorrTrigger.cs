using UnityEngine;
using System.Collections;

public class footstepCorrTrigger : MonoBehaviour {
    [SerializeField]
    GameObject src;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player") {
            src.GetComponent<AudioSource>().Play();
        }
    }
}
