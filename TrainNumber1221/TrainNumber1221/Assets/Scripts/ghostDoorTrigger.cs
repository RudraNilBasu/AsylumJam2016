using UnityEngine;
using System.Collections;

public class ghostDoorTrigger : MonoBehaviour {
    int doOnce = 0;

    AudioManager am;

    void Start()
    {
        am = AudioManager.instance;
    }

    [SerializeField]
    GameObject door;
    void OnTriggerEnter(Collider coll)
    {
        if (doOnce == 0 && coll.tag == "Player")
        {
            doOnce++;
            am.PlaySound("heartbeat");
            door.GetComponent<ghostDoor>().activate();
        }
    }
}
