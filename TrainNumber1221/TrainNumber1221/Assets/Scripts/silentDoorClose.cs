using UnityEngine;
using System.Collections;

public class silentDoorClose : MonoBehaviour {
    int doOnce = 0;


    [SerializeField]
    GameObject ghostDoor, playerWhisper, suitcase, suitcaseTrigger;

    [SerializeField]
    AudioClip whisper; // don't you feel safe anymore
    
    // Use this for initialization
    void Start () {
        playerWhisper = GameObject.Find("Player");
        if (playerWhisper == null) {
            Debug.LogError("No Player Whisper Found");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.T)) {
            playerWhisper.GetComponent<AudioSource>().clip = whisper;
            Debug.Log("DONE");
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (doOnce == 0 && coll.tag == "Player")
        {
            doOnce++;
            ghostDoor.GetComponent<ghostDoor>().CloseDoor();
            StartCoroutine(playWhisper());
        }
    }

    IEnumerator playWhisper()
    {
        yield return new WaitForSeconds(2.0f);
        playerWhisper.GetComponent<AudioSource>().clip=whisper;
        playerWhisper.GetComponent<AudioSource>().Play();
        Debug.Log("don't you feel safe anymore ?");
        suitcase.SetActive(false);
        suitcaseTrigger.SetActive(true);
    }
}
