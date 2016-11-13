using UnityEngine;
using System.Collections;

public class mirrorGhost : MonoBehaviour {
    int doOnce = 0;
    [SerializeField]
    GameObject theEnemy, theLight;

    AudioManager am;
	// Use this for initialization
	void Start () {
        am = AudioManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
	
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
    }

    void OnMouseExit()
    {
        theEnemy.SetActive(false);
    }
}
