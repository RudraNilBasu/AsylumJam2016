using UnityEngine;
using System.Collections;

public class ghostDoor : MonoBehaviour {

    float delayTime = 5.0f;
    bool knockingStarted = false, canOpen = false, willKnock=false, isOver=false;
    [SerializeField]
    GameObject thePlayer, actionImg;

    [SerializeField]
    AudioClip doorKnock, doorSlam;

    void Start()
    {
        thePlayer = GameObject.Find("Player");
        if (thePlayer == null) {
            Debug.LogError("No Player Found");
        }
    }

    void Update()
    {
        if (canOpen && !isOver && Input.GetMouseButton(0)) {
            willKnock = false;
            isOver = true;
            //Debug.Log("Start THUD");
            gameObject.GetComponent<Animation>().Play("doorSlam");
            StartCoroutine(waitAndPlay());
        }
    }

    IEnumerator waitAndPlay()
    {
        yield return new WaitForSeconds(0.4f);
        //gameObject.GetComponent<AudioSource>().Play(1);
        
        gameObject.GetComponent<AudioSource>().clip = doorSlam;
        gameObject.GetComponent<AudioSource>().Play();
        

    }

    public void activate()
    {
        knockingStarted = true;
        willKnock = true;
        knock();
    }

    void knock()
    {
        if (willKnock)
        {
            gameObject.GetComponent<Animation>().Play("doorKnock");
            //gameObject.GetComponent<AudioSource>().Play(0);
            
            gameObject.GetComponent<AudioSource>().clip = doorKnock;
            gameObject.GetComponent<AudioSource>().Play();
            
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(delayTime);
        // calling knock()
        knock();
    }

    void OnMouseOver()
    {
        if ( knockingStarted && Vector3.Distance(thePlayer.transform.position, gameObject.transform.position) < 2.0f) {
            actionImg.SetActive(true);
            canOpen = true;
        }
    }

    void OnMouseExit()
    {
        canOpen = false;
        if (knockingStarted) {
            actionImg.SetActive(false);
        }
    }
}
