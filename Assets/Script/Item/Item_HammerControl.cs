using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 해머 아이템의 동작을 구현한다
 */
public class Item_HammerControl : MonoBehaviour {

    public GameObject Player;
    public AudioClip aa;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    /*
     * 플레이어와 충돌 시의 동작
     */
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
