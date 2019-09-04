using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour {

    public GameObject Player;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (Player.GetComponent<Animator>().GetBool("IsAttacking"))
        {
            

            if (col.tag == "Box")
            {
                Debug.Log("Attacked!!");
                col.gameObject.SendMessage("Open");
            }
            if (col.tag == "Switch")
            {
                col.gameObject.SendMessage("SwitchOn");
            }
            if (col.tag == "KingBox")
            {
                col.gameObject.SendMessage("Open");
            }
        }

    }

}
