using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {
    [SerializeField]
    GameObject one, two;
	// Use this for initialization
	void Start () {
        one.SetActive(true);
        two.SetActive(false);
        StartCoroutine(wait());
	}
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.0f);
        one.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
