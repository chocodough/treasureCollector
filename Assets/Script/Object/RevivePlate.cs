using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePlate : MonoBehaviour {

    public GameObject Player;
    public int PlateNum;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Player.GetComponent<PlayerControl>().RevivePosition = Player.GetComponent<PlayerControl>().RevivePoints[PlateNum];
        }
    }
}
