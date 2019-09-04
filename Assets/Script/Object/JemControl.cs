using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JemControl : MonoBehaviour {

    public GameObject Player;

	void Start () {
        Player = GameObject.FindWithTag("Player");
	}
	
	
	void Update () {
        this.transform.parent.transform.Rotate(0, 2 * Time.deltaTime, 0);
	}

    void OnTriggerEnter(Collider col)
    {

        if(col.tag == "Player")
        {
            Player.GetComponent<Animator>().SetBool("GetGem",true);
        }
        Destroy(this.transform.parent.gameObject);
    }
}
