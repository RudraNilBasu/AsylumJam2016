using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class suitcaseFound : MonoBehaviour {
    [SerializeField]
    GameObject thePlayer, actionImg, exit;
    [SerializeField]
    Text quote;

    bool canPick = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (canPick && Input.GetMouseButton(0)) {
            actionImg.SetActive(false);
            quote.text = "My Bag..... And my ID Card is in here too..... I think the station my arrived. Have to go down quickly";
            exit.SetActive(true);
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(delay());
        }
	}

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2.0f);
        //quote.text = "";
        actionImg.SetActive(false);
        gameObject.SetActive(false);
    }

    void OnMouseOver()
    {
        if (Vector3.Distance(thePlayer.transform.position, transform.position) < 3.0f) {
            canPick = true;
            actionImg.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        canPick = false;
        actionImg.SetActive(false);
    }
}
