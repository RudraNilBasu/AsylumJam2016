using UnityEngine;
using System.Collections;

public class tapWater : MonoBehaviour {

    [SerializeField]
    GameObject thePlayer, actionImg, theWater;

    [SerializeField]
    GameObject closeInfo, waterTrigger;

    bool canOpen = false;
    bool isOpen = false;

    bool isOver = false;

    int doOnce = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (canOpen && !isOpen && Input.GetMouseButton(0) &&isOver) {
            theWater.SetActive(true);
            isOpen = true;
            actionImg.SetActive(false);
            GetComponent<AudioSource>().Play();
            closeInfo.SetActive(true);
        }

        if (isOpen && Input.GetMouseButton(1)) {
            theWater.SetActive(false);
            isOpen = false;
            actionImg.SetActive(false);
            GetComponent<AudioSource>().Stop();
            closeInfo.SetActive(false);

            if (!isOver) {
                waterTrigger.GetComponent<tapWaterTrigger>().callTrigger();
            }
        }
	}
    void OnMouseOver()
    {
        if (Vector3.Distance(thePlayer.transform.position, transform.position) < 3.0f) {
            actionImg.SetActive(true);
            canOpen = true;
            if (isOpen) {
                closeInfo.SetActive(true);
            }
        }
    }

    void OnMouseExit()
    {
        canOpen = false;
        actionImg.SetActive(false);
        if (isOpen) {
            closeInfo.SetActive(false);
        }
    }

    public void turnOn()
    {
        theWater.SetActive(true);
        isOpen = true;
        
        GetComponent<AudioSource>().Play();
        //closeInfo.SetActive(true);
    }

    public void itsOver()
    {
        isOver = true;
    }
}

