using UnityEngine;
using System.Collections;

public class mirrorGhost : MonoBehaviour {
    int doOnce = 0;
    [SerializeField]
    GameObject theEnemy, theLight, footstepTrigger;
    [SerializeField]
    GameObject light1, light2;

    AudioManager am;

    GameObject gm;
	// Use this for initialization
	void Start () {
        am = AudioManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
        gm = GameObject.Find("GameManager");
	}

    void OnMouseEnter()
    {
        if (doOnce == 0) {
            doOnce++;
            am.PlaySound("mirror");
            StartCoroutine(lightsOff());
        }
    }

    IEnumerator lightsOff()
    {
        yield return new WaitForSeconds(1.0f);// it was 0.5f
        am.PlaySound("lightSmash");
        theLight.SetActive(false);
        theEnemy.SetActive(false);
        light1.GetComponent<Animation>().Play("lightFlicker_2");
        light2.GetComponent<Animation>().Play("lightFlicker_2");
        footstepTrigger.SetActive(true);
        yield return new WaitForSeconds(15.0f);
        // start thump
        gm.GetComponent<thump>().Play();
    }

    void OnMouseExit()
    {
        theEnemy.SetActive(false);
    }
}
