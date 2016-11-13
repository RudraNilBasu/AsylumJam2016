using UnityEngine;
using System.Collections;

public class thump : MonoBehaviour {
    AudioManager am;
    float waitingTime = 8.0f;
    int count = 0;
	// Use this for initialization
	void Start () {
        am = AudioManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        startThump();
    }

    void startThump()
    {
        count++;
        if (count > 10) {
            count = 10;
        }
        am.setVolume(4, (count / 10.0f));
        am.PlaySound("thump");
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(10);
        startThump();
        /*
        if (count % 3 == 0 && waitingTime>3.0f) {
            waitingTime--;
        }
        yield return new WaitForSeconds(waitingTime);
        */
    }
}
