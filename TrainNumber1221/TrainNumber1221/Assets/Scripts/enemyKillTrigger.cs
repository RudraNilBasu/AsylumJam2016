using UnityEngine;
using System.Collections;

public class enemyKillTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject manThrow, enemy;

    [SerializeField]
    RuntimeAnimatorController enemyStand;

    AudioManager am;
    int doOnce = 0;
    // Use this for initialization
    void Start()
    {
        am = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        if (doOnce == 0 && coll.tag == "Player")
        {
            doOnce++;
            am.PlaySound("heartbeat");
            manThrow.GetComponent<AudioSource>().Play();
            manThrow.GetComponent<Animation>().Play("manThrow");
            enemy.GetComponent<Animator>().runtimeAnimatorController = enemyStand;
        }
    }

}
