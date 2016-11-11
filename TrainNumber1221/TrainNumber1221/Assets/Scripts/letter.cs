using UnityEngine;
using System.Collections;

public class letter : MonoBehaviour {

    [SerializeField]
    bool canRead = false;
    [SerializeField]
    bool isReading = false;

    [SerializeField]
    GameObject theLetter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (canRead && Input.GetButtonDown("Fire1")) {
            Read();
        }
        /*
        if (isReading && Input.GetButtonDown("Fire1")) {
            StopReading();
        }
        */
	}

    void Read()
    {
        isReading = true;
        // lock
        theLetter.SetActive(true);
    }

    void StopReading()
    {
        isReading = false;
        // unlock
        theLetter.SetActive(false);
    }

    void OnMouseOver()
    {
        // check distance
        canRead = true;
    }
    void OnMouseExit()
    {
        canRead = false;
    }
    /*
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player") {
            canRead = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            canRead = false;
        }
    }
    */
}
