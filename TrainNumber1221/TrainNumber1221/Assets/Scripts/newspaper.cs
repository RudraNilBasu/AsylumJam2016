using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class newspaper : MonoBehaviour
{

    //AudioManager am;
    /*
    [SerializeField]
    GameObject mirrorGhost, enemy;
    */

    /*
    [SerializeField]
    bool isBurnt = false;
    */
    int doOnce = 0;

    //[SerializeField]
    bool canRead = false;
    //[SerializeField]
    bool isReading = false;

    [SerializeField]
    GameObject theLetter, gm, whisper;
    // Use this for initialization

    AudioManager am;

    [SerializeField]
    GameObject thePlayer, actionImg;
    void Start()
    {
        thePlayer = GameObject.Find("Player");
        if (thePlayer == null)
        {
            Debug.LogError("NO PLAYER FOUND");
        }

        am = AudioManager.instance;
        if (am == null)
        {
            Debug.LogError("NO AM FOUND");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(thePlayer.transform.position, transform.position));

        if (canRead && Input.GetButtonDown("Fire1"))
        {
            Read();
        }

        if (isReading && Input.GetMouseButtonDown(1))
        {
            StopReading();
        }

    }

    void Read()
    {
        am.PlaySound("paper");
        actionImg.SetActive(false);
        // lock
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        theLetter.SetActive(true);
        isReading = true;


    }

    void StopReading()
    {
        am.PlaySound("paper");
        isReading = false;
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
        // unlock
        theLetter.SetActive(false);
        StartCoroutine(kill());
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(5.0f);
        // whisper
        whisper.GetComponent<AudioSource>().Play();
        // fade out
        yield return new WaitForSeconds(3.0f);
        am.PlaySound("jumpscare");
        gm.GetComponent<Fade>().BeginFade(1);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("credits");
    }

    void OnMouseOver()
    {
        // check distance
        if (!isReading && Vector3.Distance(thePlayer.transform.position, transform.position) < 3.0f)
        {
            canRead = true;
            actionImg.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        canRead = false;
        actionImg.SetActive(false);
    }
    /*
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player") {
            canRead = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            canRead = false;
        }
    }
    */
}
