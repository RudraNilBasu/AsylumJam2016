using UnityEngine;
using System.Collections;

public class ghostWalk : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void walk()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animation>().Play("ghostWalk");
    }
}
