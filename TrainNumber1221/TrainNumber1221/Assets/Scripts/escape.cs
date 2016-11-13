using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class escape : MonoBehaviour {

    bool canExit = false;
    [SerializeField]
    Text quote;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (canExit && Input.GetMouseButton(0)) {
            Debug.Log("NEXT LEVEL");
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player") {
            canExit = true;
            quote.text = "Left Click to board down the train";
        }
    }
}
