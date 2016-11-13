using UnityEngine;
using System.Collections;

public class EnemyLookPlayer : MonoBehaviour {

    Transform target;
	// Use this for initialization
	void Awake () {
        target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void look()
    {
        transform.LookAt(target);
    }
}
