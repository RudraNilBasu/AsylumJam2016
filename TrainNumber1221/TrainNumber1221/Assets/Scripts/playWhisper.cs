using UnityEngine;
using System.Collections;

public class playWhisper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKey(KeyCode.T)) {
            Play();
        }
        */
	}

    public void Play()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
