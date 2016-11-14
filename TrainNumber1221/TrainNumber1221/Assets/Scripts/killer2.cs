using UnityEngine;
using System.Collections;

public class killer2 : MonoBehaviour {
    int doOnce = 0;

    [SerializeField]
    GameObject nextDoor, enemy, manCry, trigger, lastDoorClose, lastDoorOpen, barrier;

    AudioManager am;
    // Use this for initialization
    void Start () {
        am = AudioManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (doOnce == 0 && coll.tag == "Player")
        {
            doOnce++;
            //barrier.SetActive(false);
            am.PlaySound("heartbeat");
            nextDoor.GetComponent<Animation>().Play("doorOpen");
            manCry.GetComponent<AudioSource>().Play();
            trigger.SetActive(true);
            enemy.SetActive(true);
            lastDoorClose.SetActive(false);
            lastDoorOpen.SetActive(true);
            /*
            doorBreak.GetComponent<Animation>().Play("doorCrash");
            //Debug.Log("Incoming ghost");
            */
        }
    }
}
