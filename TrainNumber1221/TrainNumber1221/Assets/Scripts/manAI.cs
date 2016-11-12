using UnityEngine;
using System.Collections;

public class manAI : MonoBehaviour {
    [SerializeField]
    GameObject theDoor;
    [SerializeField]
    Transform target;

    bool willMove = false;

    [SerializeField]
    RuntimeAnimatorController walk;

    GameObject thePlayer;
	// Use this for initialization
	void Start () {
        thePlayer = GameObject.Find("Player");
        if (thePlayer == null) {
            Debug.LogError("No Player Found");
        }
	}
	


	// Update is called once per frame
	void Update () {
        if (willMove) {
            transform.LookAt(target);
            GetComponent<Animator>().runtimeAnimatorController = walk;
        }

        if (Vector3.Distance(transform.position, target.position) < 0.5f) {
            theDoor.GetComponent<Animation>().Play("doorClose");
            gameObject.SetActive(false);
        }

        if (Vector3.Distance(thePlayer.transform.position, transform.position) < 5.0f) {
            willMove = true;
        }
	}
    
}
