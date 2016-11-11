using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    bool isOpen = false;

    float closeZpos = 0.0f;
    float openZpos = 0.8f;

    Animation anim;

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
    }

    void OpenDoor()
    {
        anim.Play("doorOpen");
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
}
