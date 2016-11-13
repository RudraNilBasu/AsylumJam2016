using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    [SerializeField]
    Transform[] waypoints;

    int index = 0;
    [SerializeField]
    RuntimeAnimatorController walkAnim;

    [SerializeField]
    Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKey(KeyCode.T)) {
            startMoving();
        }
        */
        if (target != null) {
            transform.LookAt(target);
        }
        if (target != null && Vector3.Distance(target.position, transform.position) <= 0.5f) {
            index++;
            if (index >= 3) {
                return;
            }
            target = waypoints[index];
            transform.LookAt(target);
        }
	}

    public void startMoving()
    {
        if (index >= 3) {
            return;
        }
        gameObject.GetComponent<Animator>().runtimeAnimatorController =walkAnim;
        target = waypoints[index];
        transform.LookAt(target);
    }
}
