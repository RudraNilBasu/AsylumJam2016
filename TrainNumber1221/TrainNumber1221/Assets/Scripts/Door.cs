using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    
    bool isOpen = false, isLocked=false;

    float closeZpos = 0.0f;
    float openZpos = 0.8f;

    [SerializeField]
    bool canChange = false;

    Animation anim;

    [SerializeField]
    GameObject actionImg;

    AudioManager am;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        if (anim == null) {
            Debug.LogError("No Animation component found for the door!");
        }

        am = AudioManager.instance;
        if (am == null) {
            Debug.LogError("No AM!");
        }
    }
	
	// Update is called once per frame
	void Update () {
        /*
         // Testing door open and close
        if (Input.GetKeyDown(KeyCode.T)) {
            OpenDoor();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            CloseDoor();
        }
        */
        if (canChange && !isLocked) {
            if (Input.GetButtonDown("Fire1")) {
                doorChange();
            }
        }
    }

    void OpenDoor()
    {
        anim.Play("doorOpen");
        am.PlaySound("door");
        //gameObject.GetComponent<AudioSource>().Play();
    }

    void CloseDoor()
    {
        anim.Play("doorClose");
        am.PlaySound("door");
    }

    public void doorChange()
    {
        if (!isOpen)
        {
            OpenDoor();
        }
        else {
            CloseDoor();
        }
        isOpen = !isOpen;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player") {
            canChange = true;
            actionImg.SetActive(true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player") {
            canChange = false;
            actionImg.SetActive(false);
        }
    }

    public void lockDoor()
    {
        CloseDoor();
        isLocked = true;
    }
}
