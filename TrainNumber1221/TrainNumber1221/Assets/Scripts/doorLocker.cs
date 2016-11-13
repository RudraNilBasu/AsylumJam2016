using UnityEngine;
using System.Collections;

public class doorLocker : MonoBehaviour {
    int doOnce = 0;
    [SerializeField]
    GameObject theDoor, doorKnock, ghostWalk, roomKnock, doorUnlock, ghostDoor, ghostDoorCloseTrigger;

    float timeBeforeFootstep = 30.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (doOnce==0 && coll.tag == "Player")
        {
            doOnce++;
            // Lock the Door
            theDoor.GetComponent<Door>().lockDoor();
            StartCoroutine(beginGhost());
        }
    }

    IEnumerator beginGhost()
    {
        yield return new WaitForSeconds(timeBeforeFootstep);
        // turn on a huge door noise
        doorKnock.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5.0f);
        // turn on footsteps
        ghostWalk.GetComponent<ghostWalk>().walk();
        // add a Walk() method
        yield return new WaitForSeconds(30.0f);
        ghostWalk.SetActive(false);
        roomKnock.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3.0f);
        roomKnock.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(10.0f);
        doorUnlock.GetComponent<AudioSource>().Play();
        theDoor.GetComponent<Door>().unlockDoor();
        ghostDoor.GetComponent<Animation>().Play("ghostDoorOpen");
        ghostDoorCloseTrigger.SetActive(true);
    }
}
