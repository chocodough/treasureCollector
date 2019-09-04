using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavaControl : MonoBehaviour {


    PlayerControl a;
    void Start()
    {
        a = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.gameObject.GetComponent<Animator>().SetBool("LifeIs0", true);
            //GetComponent<AudioSource>().Play();
            //a.PlayerSound.PlayOneShot(a.DieSound);

        }
    }
}
