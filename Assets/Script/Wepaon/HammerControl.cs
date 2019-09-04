using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerControl : MonoBehaviour {

    public GameObject Player;
    public bool strike = false;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    void OnTriggerEnter(Collider col)
    {
        if (Player.GetComponent<Animator>().GetBool("IsAttacking"))
        {
            if (col.tag == "Rock")
            {
                Debug.Log("Attacked!!");
                col.gameObject.GetComponentInChildren<RockControl>().isShaking = true;
                col.gameObject.GetComponent<AudioSource>().Play();
            }

            if (col.tag == "Box")
            {
                Debug.Log("Attacked!!");
                col.gameObject.SendMessage("Open");
            }
            if (col.tag == "KingBox")
            {
                col.gameObject.SendMessage("Open");
            }
        }


     
    }
}
