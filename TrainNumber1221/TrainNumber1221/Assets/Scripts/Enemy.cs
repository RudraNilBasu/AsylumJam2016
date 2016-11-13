using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    [SerializeField]
    GameObject playerCam;

    [SerializeField]
    Text quote;

    int doOnce = 0;

    AudioManager am;

    [SerializeField]
    bool sleep=false;
	// Use this for initialization
	void Start () {
        am = AudioManager.instance;
	}
    float n_amt = 0;
    float r_amt = 0;
    float t = 0;

    [SerializeField]
    GameObject gm;
    // Update is called once per frame
    void Update () {
        /*
        if (sleep) {
            
            n_amt = Mathf.Lerp(0.1f, 1.5f, t);
            r_amt = Mathf.Lerp(-0.1f, -0.3f, t);
            t += 0.1f * Time.deltaTime;
            if(t>1.0f)
            {
                sleep = false;
            }
            //r_amt += Mathf.Lerp(-0.1f, -0.3f, 10*Time.deltaTime);
            //r_amt = -0.1f;
            Debug.Log("n="+n_amt+"  r="+r_amt);
            playerCam.GetComponent<NoiseAndScratches>().grainIntensityMin = n_amt;
            playerCam.GetComponent<Grayscale>().rampOffset = r_amt;
            
        }
        */
	}

    void OnMouseOver()
    {
        if (doOnce == 0)
        {
            doOnce++;
            am.PlaySound("heartbeat");
            StartCoroutine(delay());
            //sleep = true;
            /*
            playerCam.GetComponent<NoiseAndGrain>();// 0.1-1.5
            playerCam.GetComponent<Grayscale>().rampOffset;//-0.1 -> -0.3
            */
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.0f);
        playerCam.GetComponent<MotionBlur>().enabled = true;
        
        yield return new WaitForSeconds(6.0f);
        gm.GetComponent<Fade>().BeginFade(1);
        //sleep = true;
        //playerCam.GetComponent<Grayscale>().rampOffset = -1f;
        playerCam.GetComponent<AudioListener>().enabled = false;
        // Restart
        yield return new WaitForSeconds(15.0f);
        playerCam.GetComponent<MotionBlur>().enabled = false;
        gm.GetComponent<reset>().restart();
        gameObject.SetActive(false);
        //quote.text = "HIDE";
    }
}
