using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_HammerControl : MonoBehaviour {

    public GameObject Player;
    public AudioClip aa;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
   
    void OnTriggerEnter(Collider col)
    {      
        if (col.tag == "Player")
        {
            Player.GetComponent<PlayerControl>().GetHammer = true;
            Destroy(transform.parent.gameObject);
            AudioSource.PlayClipAtPoint(aa, transform.position);
        }
    }
}
