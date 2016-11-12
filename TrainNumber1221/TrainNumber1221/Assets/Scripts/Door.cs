using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    bool isOpen = false;

    float closeZpos = 0.0f;
    float openZpos = 0.8f;

    [SerializeField]
    bool canChange = false;

    Animation anim;

    [SerializeField]
    GameObject actionImg;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        if (anim == null) {
            Debug.LogError("No Animation component found for the door!");
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
        if (canChange) {
            if (Input.GetButtonDown("Fire1")) {
                doorChange();
            }
        }
    }

    void OpenDoor()
    {
        anim.Play("doorOpen");
        gameObject.GetComponent<AudioSource>().Play();
    }

    void CloseDoor()
    {
        anim.Play("doorClose");
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
}
