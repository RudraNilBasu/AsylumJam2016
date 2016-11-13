using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class reset : MonoBehaviour {
    [SerializeField]
    GameObject thePlayer, spawnPosition, playerCam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void restart()
    {
        gameObject.GetComponent<AudioSource>().Stop();
        playerCam.GetComponent<AudioListener>().enabled = true;
        thePlayer.transform.position = spawnPosition.transform.position;
        gameObject.GetComponent<Fade>().BeginFade(-1);
        
    }
}
