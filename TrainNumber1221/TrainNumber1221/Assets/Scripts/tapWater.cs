using UnityEngine;
using System.Collections;

public class tapWater : MonoBehaviour {

    [SerializeField]
    GameObject thePlayer, actionImg, theWater;

    [SerializeField]
    GameObject closeInfo;

    bool canOpen = false;
    bool isOpen = false;

    int doOnce = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (canOpen && !isOpen && Input.GetMouseButton(0)) {
            theWater.SetActive(true);
            isOpen = true;
            actionImg.SetActive(false);
            GetComponent<AudioSource>().Play();
            closeInfo.SetActive(true);

            if (doOnce == 0) {
                doOnce++;
            }
        }

        if (isOpen && Input.GetMouseButton(1)) {
            theWater.SetActive(false);
            isOpen = false;
            actionImg.SetActive(false);
            GetComponent<AudioSource>().Stop();
            closeInfo.SetActive(false);
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
}

