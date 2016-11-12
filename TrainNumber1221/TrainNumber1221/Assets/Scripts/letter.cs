using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class letter : MonoBehaviour {

    //[SerializeField]
    bool canRead = false;
    //[SerializeField]
    bool isReading = false;

    [SerializeField]
    GameObject theLetter;
    // Use this for initialization

    [SerializeField]
    GameObject thePlayer, actionImg;
	void Start () {
        thePlayer = GameObject.Find("Player");
        if (thePlayer == null) {
            Debug.LogError("NO PLAYER FOUND");
        }
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Vector3.Distance(thePlayer.transform.position, transform.position));

        if (canRead && Input.GetButtonDown("Fire1")) {
            Read();
        }
        
        if (isReading && Input.GetMouseButtonDown(1)) {
            StopReading();
        }
        
	}

    void Read()
    {
        
        actionImg.SetActive(false);
        // lock
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        theLetter.SetActive(true);
        isReading = true;
    }

    void StopReading()
    {
        isReading = false; 
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
        // unlock
        theLetter.SetActive(false);
    }

    void OnMouseOver()
    {
        // check distance
        if (!isReading && Vector3.Distance(thePlayer.transform.position, transform.position) < 2.0f)
        {
            canRead = true;
            actionImg.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        canRead = false;
        actionImg.SetActive(false);
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
