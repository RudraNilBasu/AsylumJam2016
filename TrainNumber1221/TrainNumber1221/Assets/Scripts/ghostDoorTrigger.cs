using UnityEngine;
using System.Collections;

public class ghostDoorTrigger : MonoBehaviour {
    int doOnce = 0;
    [SerializeField]
    GameObject door;
    void OnTriggerEnter(Collider coll)
    {
        if (doOnce == 0 && coll.tag == "Player")
        {
            doOnce++;
            door.GetComponent<ghostDoor>().activate();
        }
    }
}
